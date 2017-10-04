using Orchard;
using Orchard.Environment.Extensions;
using System.IO;
using System.Net;
using System.Web.Mvc;
using System.Drawing;
using System.Drawing.Imaging;
using System.Web;
using Moov2.Orchard.SEO.Models;
using Orchard.ContentManagement;

namespace Moov2.Orchard.SEO.Controllers {
    [OrchardFeature("Moov2.Orchard.SEO.Favicon")]
    public class FaviconController : Controller
    {
        #region Dependencies
        private readonly IOrchardServices _services;
        private readonly IWorkContextAccessor _workContextAccessor;
        #endregion

        #region Constructor

        public FaviconController(IOrchardServices services, IWorkContextAccessor workContextAccessor)
        {
            _services = services;
            _workContextAccessor = workContextAccessor;
        }

        #endregion

        #region Actions

        public HttpContextBase GetFavicon()
        {
            var favicon = _services.WorkContext.CurrentSite.As<SEOSettingsPart>().Favicon;
            var context = _workContextAccessor.GetContext().HttpContext;
            Bitmap image = GetBitmap(context, favicon);

            if (image == null) {
                context.Response.Status = "404 Not Found";
                context.Response.StatusCode = 404;
                context.Response.End();
                return context;
            }

            context.Response.ContentType = "image/x-icon";
            context.Response.Cache.SetCacheability(HttpCacheability.Public);
            context.Response.BufferOutput = false;

            using (image) {
                using (MemoryStream ms = new MemoryStream()) {
                    image.Save(ms, ImageFormat.Png);
                    ms.WriteTo(context.Response.OutputStream);
                }
            }

            return context;
        }

        #endregion

        #region Helper
        public Bitmap GetBitmap(HttpContextBase context, string favicon) {

            if (string.IsNullOrWhiteSpace(favicon)) {
                return null;
            }

            var isHttp = (favicon.StartsWith("http") ? true : false);

            if (isHttp) {
                WebRequest request = WebRequest.Create(favicon);
                WebResponse response;
                try {
                    response = request.GetResponse();
                } catch {
                    return null;
                }
                Stream responseStream = response.GetResponseStream();
                return new Bitmap(responseStream);
            }

            try {
                return new Bitmap(context.Server.MapPath(favicon));
            } catch {
                return null;
            }
            
        }
        #endregion
    }
}