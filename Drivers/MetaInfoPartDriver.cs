using Moov2.Orchard.SEO.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Moov2.Orchard.SEO.Drivers
{
    public class MetaInfoPartDriver : ContentPartDriver<MetaInfoPart>
    {
        #region Constants

        private const string TemplateName = "Parts.MetaInfo.MetaInfoPart";

        #endregion

        #region Dependencies

        public Localizer T { get; set; }

        public WorkContext WorkContext { get; set; }

        #endregion

        #region Constructor

        public MetaInfoPartDriver(IWorkContextAccessor workContextAccessor)
        {
            WorkContext = workContextAccessor.GetContext();
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

            return Combined(
                ContentShape("Parts_MetaInfo", () => shapeHelper.Parts_MetaInfo(Description: part.Description, Keywords: part.Keywords, Title: pageTitle, HasPageTitle: (string.IsNullOrEmpty(part.Title) ? false : true) ))
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