using Orchard.ContentManagement.Records;

namespace Moov2.Orchard.SEO.Models
{
    public class RedirectPartRecord : ContentPartVersionRecord
    {
        public virtual string RedirectTo { get; set; }
    }
}