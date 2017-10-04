using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using System;

namespace Moov2.Orchard.SEO.Models
{
    public class SEOSettingsPart : ContentPart
    {
        public const string CacheKey = "SEOSettingsPart";

        public bool ForceSSL {
            get {
                var attributeValue = this.As<InfosetPart>().Get<SEOSettingsPart>("ForceSSL");
                return !string.IsNullOrWhiteSpace(attributeValue) && Convert.ToBoolean(attributeValue);
            }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("ForceSSL", value.ToString()); }
        }

        public bool RedirectToNonWWW {
            get {
                var attributeValue = this.As<InfosetPart>().Get<SEOSettingsPart>("RedirectToNonWWW");
                return !string.IsNullOrWhiteSpace(attributeValue) && Convert.ToBoolean(attributeValue);
            }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("RedirectToNonWWW", value.ToString()); }
        }

        public string Robots {
            get { return  this.As<InfosetPart>().Get<SEOSettingsPart>("Robots"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("Robots", (value == null ? "" : value.ToString())); }
        }

        public string Favicon {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("Favicon"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("Favicon", (value == null ? "" : value.ToString())); }
        }

        public string TwitterUsername {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("TwitterUsername"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("TwitterUsername", (value == null ? "" : value.ToString())); }
        }

        public string DefaultDescription {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("DefaultDescription"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("DefaultDescription", (value == null ? "" : value.ToString())); }
        }

        public string DefaultKeywords {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("DefaultKeywords"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("DefaultKeywords", (value == null ? "" : value.ToString())); }
        }

        public string GoogleAnalytics {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("GoogleAnalytics"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("GoogleAnalytics", (value == null ? "" : value.ToString())); }
        }

        public string GoogleTagManager {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("GoogleTagManager"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("GoogleTagManager", (value == null ? "" : value.ToString())); }
        }
    }
}