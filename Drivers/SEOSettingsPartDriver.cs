
using Moov2.Orchard.SEO.Models;
using Moov2.Orchard.SEO.Options;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;
using System;

namespace Moov2.Orchard.SEO.Drivers
{
    public class SEOSettingsPartDriver : ContentPartDriver<SEOSettingsPart>
    {
        #region Dependencies
        private readonly ISignals _signals;
        #endregion

        #region Constants
        private const string TemplateName = "Parts.SEOSettings";
        #endregion

        #region Constructor
        public SEOSettingsPartDriver(ISignals signals)
        {
            _signals = signals;
            T = NullLocalizer.Instance;
        }
        #endregion

        #region Orchard Properties
        public Localizer T { get; set; }
        #endregion

        #region Overrides
        protected override string Prefix
        {
            get { return "SEOSettings"; }
        }

        #region Editor
        protected override DriverResult Editor(SEOSettingsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_SEOSettings_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix))
                .OnGroup("SEO");
        }

        protected override DriverResult Editor(SEOSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            if (updater.TryUpdateModel(part, Prefix, null, null))
            {
                ValidateSiteUrl(part, updater);
                ValidateSiteUrlAndWWWCompatibility(part, updater);
                ValidateSiteUrlAndForceSSLCompatibility(part, updater);

                _signals.Trigger(SEOSettingsPart.CacheKey);
            }

            return Editor(part, shapeHelper);
        }
        #endregion

        #region Importing
        protected override void Importing(SEOSettingsPart part, ImportContentContext context)
        {
            _signals.Trigger(SEOSettingsPart.CacheKey);
        }
        #endregion

        #endregion

        #region Helpers
        private void ValidateSiteUrl(SEOSettingsPart part, IUpdateModel updater)
        {
            if (string.IsNullOrWhiteSpace(part.RedirectToSiteUrl))
                return;

            var url = part.RedirectToSiteUrl;

            // We need to ensure that this will parse as a URI so prepend a URL scheme
            if (!url.StartsWith("http://", StringComparison.OrdinalIgnoreCase) && !url.StartsWith("https://", StringComparison.OrdinalIgnoreCase))
                url = (part.ForceSSL ? "https://" : "http://") + url.TrimStart('/');

            part.RedirectToSiteUrl = url;

            try
            {
                new Uri(part.RedirectToSiteUrl);
            }catch(Exception)
            {
                updater.AddModelError("RedirectToSiteUrl", T("Couldn't parse 'Redirect to Site URL' please ensure it is in the correct format"));
            }
        }

        private void ValidateSiteUrlAndWWWCompatibility(SEOSettingsPart part, IUpdateModel updater)
        {
            if (RedirectOptions.Domain.Equals(part.Redirect, StringComparison.OrdinalIgnoreCase) && string.IsNullOrWhiteSpace(part.RedirectToSiteUrl))
            {
                updater.AddModelError("RedirectToSiteUrl", T("Redirect to Domain is required when redirecting to domain"));
                return;
            }
        }

        private void ValidateSiteUrlAndForceSSLCompatibility(SEOSettingsPart part, IUpdateModel updater)
        {
            if (!part.ForceSSL || string.IsNullOrWhiteSpace(part.RedirectToSiteUrl))
                return;

            if (!part.RedirectToSiteUrl.StartsWith("https://"))
                updater.AddModelError("RedirectToSiteUrl", T("Incompatible settings of 'ForceSSL' and 'Redirect to Site URL' because URL does not contain https:// which would cause a double redirect"));
        }

        #endregion
    }
}
