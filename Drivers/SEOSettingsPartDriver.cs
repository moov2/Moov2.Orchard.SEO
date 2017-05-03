
using Moov2.Orchard.SEO.Models;
using Orchard.Caching;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Drivers;
using Orchard.ContentManagement.Handlers;
using Orchard.Localization;

namespace Moov2.Orchard.SEO.Drivers
{
    public class SEOSettingsPartDriver : ContentPartDriver<SEOSettingsPart>
    {
        private readonly ISignals _signals;
        private const string TemplateName = "Parts.SEOSettings";

        public SEOSettingsPartDriver(ISignals signals)
        {
            _signals = signals;
            T = NullLocalizer.Instance;
        }

        public Localizer T { get; set; }

        protected override string Prefix {
            get { return "SEOSettings"; }
        }

        protected override DriverResult Editor(SEOSettingsPart part, dynamic shapeHelper)
        {
            return ContentShape("Parts_SEOSettings_Edit",
                () => shapeHelper.EditorTemplate(TemplateName: TemplateName, Model: part, Prefix: Prefix))
                .OnGroup("SEO");
        }

        protected override DriverResult Editor(SEOSettingsPart part, IUpdateModel updater, dynamic shapeHelper)
        {
            if (updater.TryUpdateModel(part, Prefix, null, null))
                _signals.Trigger(SEOSettingsPart.CacheKey);

            return Editor(part, shapeHelper);
        }

        protected override void Importing(SEOSettingsPart part, ImportContentContext context)
        {
            _signals.Trigger(SEOSettingsPart.CacheKey);
        }
    }
}
