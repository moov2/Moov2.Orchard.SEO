using Moov2.Orchard.SEO.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Moov2.Orchard.SEO.Drivers
{
    public class RedirectPartDriver : ContentPartDriver<RedirectPart> { 
        #region Constants

        private const string TemplateName = "Parts.Redirect.RedirectPart";

        #endregion

        #region Dependencies

        public Localizer T { get; set; }
        public WorkContext WorkContext { get; set; }

        #endregion

        #region Constructor

        public RedirectPartDriver(IWorkContextAccessor workContextAccessor)
        {
            WorkContext = workContextAccessor.GetContext();
        }

        #endregion

        #region AbstractOverrides

        protected override string Prefix {
            get { return "Redirect"; }
        }

        #region Display 

        protected override DriverResult Display(RedirectPart part, string displayType, dynamic shapeHelper)
        {
            if (displayType != "Detail")
                return null;

            WorkContext.HttpContext.Response.RedirectPermanent(part.RedirectTo, true);
            return null;
        }

        #endregion

        #region Editor 

        protected override DriverResult Editor(RedirectPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_Redirect_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix));
        }

        protected override DriverResult Editor(RedirectPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            updater.TryUpdateModel(part, Prefix, null, null);
            return Editor(part, shapeHelper);
        }

        #endregion

        #region Importing

        protected override void Importing(RedirectPart part, ImportContentContext context)
        {
            // Don't do anything if the tag is not specified.
            if (context.Data.Element(part.PartDefinition.Name) == null)
                return;

            context.ImportAttribute(part.PartDefinition.Name, "RedirectTo", description => part.RedirectTo = description);
        }

        #endregion

        #region Exporting

        protected override void Exporting(RedirectPart part, ExportContentContext context)
        {
            context.Element(part.PartDefinition.Name).SetAttributeValue("RedirectTo", part.RedirectTo);
        }

        #endregion

        #endregion
    }
}