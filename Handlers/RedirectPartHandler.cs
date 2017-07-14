using Moov2.Orchard.SEO.Models;
using Orchard.ContentManagement.Handlers;
using Orchard.Data;
namespace Moov2.Orchard.SEO.Handlers
{
    public class RedirectPartHandler : ContentHandler
    {
        public RedirectPartHandler(IRepository<RedirectPartRecord> repository)
        {
            Filters.Add(StorageFilter.For(repository));

            OnGetDisplayShape<RedirectPart>((context, redirect) => {
                if (context.DisplayType != "Detail")
                    return;

                var url = redirect.RedirectTo;
            });
        }
    }
}