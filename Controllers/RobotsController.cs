using Moov2.Orchard.SEO.Models;
using Orchard;
using Orchard.ContentManagement;
using System.Web.Mvc;

namespace Moov2.Orchard.SEO.Controllers
{
    public class RobotsController : Controller
    {
        #region Dependencies
        private readonly IOrchardServices _services;
        #endregion

        #region Constructor

        public RobotsController(IOrchardServices services)
        {
            _services = services;
        }

        #endregion

        public string GetRobots()
        {
            return !string.IsNullOrEmpty(_services.WorkContext.CurrentSite.As<SEOSettingsPart>().Robots) ? _services.WorkContext.CurrentSite.As<SEOSettingsPart>().Robots : "";
        }
    }
}