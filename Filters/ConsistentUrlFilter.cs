using Moov2.Orchard.SEO.Models;
using Moov2.Orchard.SEO.Options;
using Moov2.Orchard.SEO.Services;
using Orchard;
using Orchard.Localization;
using Orchard.Logging;
using Orchard.Mvc.Filters;
using System;
using System.Linq;
using System.Web.Mvc;

namespace Moov2.Orchard.SEO.Filters
{
    public class ConsistentUrlFilter : FilterProvider, IActionFilter
    {
        private readonly IOrchardServices _orchardServices;
        private readonly ISEOSettingsProvider _seoSettingsProvider;

        public ILogger Logger { get; set; } = new NullLogger();

        public ConsistentUrlFilter(IOrchardServices orchardServices, ISEOSettingsProvider seoSettingsProvider)
        {
            _orchardServices = orchardServices;
            _seoSettingsProvider = seoSettingsProvider;
        }
        public Localizer T { get; set; }

        public void OnActionExecuted(ActionExecutedContext filterContext)
        {
            
        }

        public void OnActionExecuting(ActionExecutingContext filterContext)
        {
            var settings = _seoSettingsProvider.GetSettings();

            if (filterContext.IsChildAction)
                return;
            
            var request = filterContext.HttpContext.Request;

            if (CheckIfIgnored(settings, request.Url.ToString()))
                return;

            var consistentRequest = new Uri(request.Url.ToString());

            consistentRequest = ValidateWWW(settings, consistentRequest);
            consistentRequest = ValidateNonWWW(settings, consistentRequest);
            consistentRequest = ValidateSSL(settings, consistentRequest);
            consistentRequest = ValidateSiteUrl(settings, consistentRequest);

            if (!consistentRequest.ToString().Equals(request.Url.ToString())) {
                filterContext.Result = new RedirectResult(consistentRequest.ToString());
                return;
            }
        }

        #region Helpers

        private bool CheckIfIgnored(SEOSettingsPart settings, string url)
        {
            if (string.IsNullOrWhiteSpace(settings.IgnoredUrls))
                return false;

            var ignoredUrls = settings.IgnoredUrls.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries);

            return settings.IgnoredUrls.Split(new string[] { "\n" }, StringSplitOptions.RemoveEmptyEntries).Any(x => url.StartsWith(x));
        }

        private Uri ValidateSiteUrl(SEOSettingsPart settings, Uri uri)
        {
            if (settings.Redirect != RedirectOptions.Domain || string.IsNullOrWhiteSpace(settings.RedirectToSiteUrl))
                return uri;

            Uri requestedUri;

            try
            {
                requestedUri = new Uri(settings.RedirectToSiteUrl);
            }
            catch (Exception e)
            {
                Logger.Error(e, "Error parsing RedirectToSiteURL, skipping redirect");
                return uri;
            }

            if (requestedUri.Host == null || requestedUri.Host.Equals(uri.Host, StringComparison.OrdinalIgnoreCase))
                return uri;

            var builder = new UriBuilder(uri);
            builder.Host = requestedUri.Host;
            return builder.Uri;
        }

        private Uri ValidateSSL(SEOSettingsPart settings, Uri url)
        {
            if (!settings.ForceSSL)
                return url;

            if (url.ToString().StartsWith("http://"))
                return new Uri(url.ToString().Replace("http://", "https://"));

            return url;
        }

        private Uri ValidateWWW(SEOSettingsPart settings, Uri url)
        {
            if (settings.Redirect != RedirectOptions.NonWWW)
                return url;

            if (url.Authority.StartsWith("www."))
                return new Uri(url.ToString().Replace("www.", ""));
            
            return url;
        }

        private Uri ValidateNonWWW(SEOSettingsPart settings, Uri url) {
            if (settings.Redirect != RedirectOptions.WWW)
                return url;
            
            if (!url.Authority.StartsWith("www."))
                return new Uri(url.ToString().Replace(string.Format("{0}://", url.Scheme), string.Format("{0}://www.", url.Scheme)));

            return url;
        }

        #endregion
    }
}