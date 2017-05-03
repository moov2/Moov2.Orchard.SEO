using Moov2.Orchard.SEO.Models;
using Orchard;

namespace Moov2.Orchard.SEO.Services
{
    public interface ISEOSettingsProvider : IDependency
    {
        SEOSettingsPart GetSettings();
    }
}
