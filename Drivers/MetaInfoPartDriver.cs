using Moov2.Orchard.SEO.Models;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Moov2.Orchard.SEO.Drivers
{
    public class MetaInfoPartDriver : ContentPartDriver<MetaInfoPart>
    {

        private const string TemplateName = "Parts.MetaInfo.MetaInfoPart";

        public Localizer T { get; set; }

        protected override string Prefix {
            get { return "MetaInfo"; }
        }

        protected override DriverResult Display(MetaInfoPart part, string displayType, dynamic shapeHelper)
        {
            return Combined(
                ContentShape("Parts_MetaInfo", () => shapeHelper.Parts_MetaInfo(Description: part.Description, Keywords: part.Keywords))
            );
        }

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

        protected override void Importing(MetaInfoPart part, ImportContentContext context)
        {
            // Don't do anything if the tag is not specified.
            if (context.Data.Element(part.PartDefinition.Name) == null)
                return;

            context.ImportAttribute(part.PartDefinition.Name, "Description", description => part.Description = description);
            context.ImportAttribute(part.PartDefinition.Name, "Keywords", keywords => part.Keywords = keywords);
        }

        protected override void Exporting(MetaInfoPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("Description", part.Description);
            context.Element(part.PartDefinition.Name).SetAttributeValue("Keywords", part.Keywords);
        }
    }
}