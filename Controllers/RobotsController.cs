using Moov2.Orchard.SEO.Models;
using Orchard;
using Orchard.ContentManagement;
using Orchard.Environment.Extensions;
using System.Web.Mvc;

namespace Moov2.Orchard.SEO.Controllers
{
    [OrchardFeature("Moov2.Orchard.SEO.Robots")]
    public class RobotsController : Controller
    {
        #region Constants

        /// <summary>
        /// Default robots.txt disable robots from crawling the site.
        /// </summary>
        private const string DefaultRobotsTxt = "User-agent: *\nDisallow: /";
        private const string ContentType = "text/plain";

        #endregion

        #region Dependencies
        private readonly IOrchardServices _services;
        #endregion

        #region Constructor

        public RobotsController(IOrchardServices services)
        {
            _services = services;
        }

        #endregion

        #region Actions

        public ActionResult GetRobots()
        {
            return Content(!string.IsNullOrEmpty(_services.WorkContext.CurrentSite.As<SEOSettingsPart>().Robots) ? _services.WorkContext.CurrentSite.As<SEOSettingsPart>().Robots : DefaultRobotsTxt, ContentType);
        }

        #endregion
    }
}