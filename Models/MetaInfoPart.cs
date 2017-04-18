using Orchard.ContentManagement;

namespace Moov2.Orchard.SEO.Models
{
    public class MetaInfoPart : ContentPart<MetaInfoPartRecord>
    {
        public string Description {
            get => Retrieve(x => x.Description); set => Store(x => x.Description, value);
        }

        public string Keywords {
            get => Retrieve(x => x.Keywords); set => Store(x => x.Keywords, value);
        }
    }
}