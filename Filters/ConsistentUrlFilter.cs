using Moov2.Orchard.SEO.Models;
using Moov2.Orchard.SEO.Services;
using Orchard;
using Orchard.Localization;
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
            var consistentRequest = ValidateWWW(settings, request.Url);

            if (!consistentRequest.ToString().Equals(request.Url.ToString())) {
                filterContext.Result = new RedirectResult(consistentRequest.ToString());
                return;
            }
        }

        #region Helpers

        private Uri ValidateWWW(SEOSettingsPart settings, Uri url)
        {
            if (!settings.RedirectToNonWWW)
                return url;

            if (url.Authority.StartsWith("www."))
                return new Uri(url.ToString().Replace("www.", ""));
            
            return url;
        }

        #endregion
    }
}