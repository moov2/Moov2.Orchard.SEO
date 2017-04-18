using Moov2.Orchard.SEO.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;

namespace Moov2.Orchard.SEO.Handlers
{
    public class MetaInfoPartHandler : ContentHandler
    {
        public MetaInfoPartHandler(IRepository<MetaInfoPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));
        }
    }
}