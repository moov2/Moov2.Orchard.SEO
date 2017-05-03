using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using System;

namespace Moov2.Orchard.SEO.Models
{
    public class SEOSettingsPart : ContentPart
    {
        public const string CacheKey = "SEOSettingsPart";

        public bool RedirectToNonWWW {
            get {
                var attributeValue = this.As<InfosetPart>().Get<SEOSettingsPart>("RedirectToNonWWW");
                return !string.IsNullOrWhiteSpace(attributeValue) && Convert.ToBoolean(attributeValue);
            }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("RedirectToNonWWW", value.ToString()); }
        }
    }
}