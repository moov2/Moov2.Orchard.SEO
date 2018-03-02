using Moov2.Orchard.SEO.Models;
using Moov2.Orchard.SEO.Services;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;
using Orchard.Mvc.Html;
using System.Web;

namespace Moov2.Orchard.SEO.Drivers
{
    public class MetaInfoPartDriver : ContentPartDriver<MetaInfoPart>
    {
        #region Constants

        private const string TemplateName = "Parts.MetaInfo.MetaInfoPart";
        private readonly ISEOSettingsProvider _seoSettingsProvider;

        #endregion

        #region Dependencies

        public Localizer T { get; set; }

        public WorkContext WorkContext { get; set; }

        #endregion

        #region Constructor

        public MetaInfoPartDriver(IWorkContextAccessor workContextAccessor, ISEOSettingsProvider seoSettingsProvider)
        {
            WorkContext = workContextAccessor.GetContext();
            _seoSettingsProvider = seoSettingsProvider;
        }

        #endregion

        #region AbstractOverrides

        protected override string Prefix {
            get { return "MetaInfo"; }
        }

        #region Display 

        protected override DriverResult Display(MetaInfoPart part, string displayType, dynamic shapeHelper)
        {
            var pageTitle = string.IsNullOrEmpty(part.Title) ? WorkContext.CurrentSite.SiteName : part.Title;
            var pageTitleWithSiteName = string.IsNullOrEmpty(part.Title) ? WorkContext.CurrentSite.SiteName : string.Format("{0}{1}{2}", WorkContext.CurrentSite.SiteName, WorkContext.CurrentSite.PageTitleSeparator, part.Title);

            var pageUrlHelper = new System.Web.Mvc.UrlHelper(HttpContext.Current.Request.RequestContext);
            var pageUrl = string.Format("{0}{1}", WorkContext.CurrentSite.BaseUrl, pageUrlHelper.ItemDisplayUrl((ContentItem)part.ContentItem));

            var currentCulture = WorkContext.CurrentCulture.Replace("-", "_");

            var seoSettings = _seoSettingsProvider.GetSettings();

            var twitterUsername = string.IsNullOrEmpty(seoSettings.TwitterUsername) ? string.Empty : (seoSettings.TwitterUsername.StartsWith("@") ? seoSettings.TwitterUsername : string.Format("@{0}", seoSettings.TwitterUsername));

            return Combined(
                ContentShape("Parts_MetaInfo", () => 
                shapeHelper.Parts_MetaInfo(
                    Description: (string.IsNullOrWhiteSpace(part.Description) ? seoSettings.DefaultDescription : part.Description), 
                    Keywords: (string.IsNullOrWhiteSpace(part.Keywords) ? seoSettings.DefaultKeywords: part.Keywords), 
                    Title: pageTitle, 
                    PageTitleWithSiteName: pageTitleWithSiteName, 
                    HasPageTitle: (string.IsNullOrEmpty(part.Title) ? false : true),
                    TwitterUsername: twitterUsername,
                    GoogleAnalytics: seoSettings.GoogleAnalytics,
                    GoogleTagManager: seoSettings.GoogleTagManager,
                    PageUrl: pageUrl, 
                    CurrentCulture: currentCulture))
            );
        }

        #endregion

        #region Editor 

        protected override DriverResult Editor(MetaInfoPart part, dynamic shapeHelper)
        {

            return ContentShape("Parts_MetaInfo_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix));
        }
    
        protected override DriverResult Editor(MetaInfoPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);

            return Editor(part, shapeHelper);
        }

        #endregion

        #region Importing

        protected override void Importing(MetaInfoPart part, ImportContentContext context)
        {
            // Don't do anything if the tag is not specified.
            if (context.Data.Element(part.PartDefinition.Name) == null)
                return;

            context.ImportAttribute(part.PartDefinition.Name, "Description", description => part.Description = description);
            context.ImportAttribute(part.PartDefinition.Name, "Keywords", keywords => part.Keywords = keywords);
            context.ImportAttribute(part.PartDefinition.Name, "Title", title => part.Title = title);
        }

        #endregion

        #region Exporting

        protected override void Exporting(MetaInfoPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Description", part.Description);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Keywords", part.Keywords);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Title", part.Title);
        }

        #endregion

        #endregion
    }
}