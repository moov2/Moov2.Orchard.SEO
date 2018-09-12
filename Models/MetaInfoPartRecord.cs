using Orchard.ContentManagement.Records;

namespace Moov2.Orchard.SEO.Models
{
    public class MetaInfoPartRecord : ContentPartVersionRecord
    {
        public virtual string Description { get; set; }
        public virtual string Keywords { get; set; }
        public virtual string Title { get; set; }
        public virtual string TwitterImage { get; set; }
        public virtual string OGImage { get; set; }
    }
}