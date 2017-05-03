using Moov2.Orchard.SEO.Models;
using Orchard.ContentManagement;
using Orchard.Caching;
using Orchard;

namespace Moov2.Orchard.SEO.Services
{
    public class SEOSettingsProvider : ISEOSettingsProvider
    {
        private readonly IWorkContextAccessor _workContextAccessor;
        private readonly ICacheManager _cacheManager;
        private readonly ISignals _signals;

        public SEOSettingsProvider(
            IWorkContextAccessor workContextAccessor,
            ICacheManager cacheManager,
            ISignals signals)
        {
            _workContextAccessor = workContextAccessor;
            _cacheManager = cacheManager;
            _signals = signals;
        }

        public SEOSettingsPart GetSettings()
        {
            return _cacheManager.Get("SslSettings",
                ctx => {
                    ctx.Monitor(_signals.When(SEOSettingsPart.CacheKey));
                    return _workContextAccessor.GetContext().CurrentSite.As<SEOSettingsPart>();
                });
        }
    }
}