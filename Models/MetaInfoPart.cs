using Orchard.ContentManagement;

namespace Moov2.Orchard.SEO.Models
{
    public class MetaInfoPart : ContentPart<MetaInfoPartRecord>
    {
        public string Description {
            get { return Retrieve(x => x.Description); }
            set { Store(x => x.Description, value); }
        }

        public string Keywords {
            get { return Retrieve(x => x.Keywords); }
            set { Store(x => x.Keywords, value); }
        }

        public string Title {
            get { return Retrieve(x => x.Title); }
            set { Store(x => x.Title, value); }
        }
    }
}