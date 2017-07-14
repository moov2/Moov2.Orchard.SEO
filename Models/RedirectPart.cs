using System;
using Orchard.ContentManagement;
using Orchard.ContentManagement.Aspects;
using Orchard.Mvc.Html;
using System.Web.Mvc;
using Orchard.Autoroute.Models;

namespace Moov2.Orchard.SEO.Models
{
    public class RedirectPart : ContentPart<RedirectPartRecord>, ITitleAspect
    {
        public string RedirectTo {
            get { return Retrieve(x => x.RedirectTo); }
            set { Store(x => x.RedirectTo, value); }
        }

        public string Title {
            get {
                var autoroutePart = this.As<AutoroutePart>();
                return (ContentItem.Id == 0 || autoroutePart == null) ? "Redirect" : string.Format("Redirect from /{0}", autoroutePart.Path);
            }
        }
    }
}