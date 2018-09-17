using Orchard.ContentManagement;
using Orchard.ContentManagement.FieldStorage.InfosetStorage;
using System;
using System.Collections.Generic;

namespace Moov2.Orchard.SEO.Models {
    public class SEOSettingsPart : ContentPart {
        public const string CacheKey = "SEOSettingsPart";


        public Dictionary<string, string> Options {
            get {
                var options = new Dictionary<string, string>();
                options.Add("NoRedirect", "No Redirect");
                options.Add("RedirectToNonWWW", "Redirect to none WWW");
                options.Add("RedirectToWWW", "Redirect to WWW");

                return options;
            }
        }

        public bool ForceSSL {
            get {
                var attributeValue = this.As<InfosetPart>().Get<SEOSettingsPart>("ForceSSL");
                return !string.IsNullOrWhiteSpace(attributeValue) && Convert.ToBoolean(attributeValue);
            }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("ForceSSL", value.ToString()); }
        }

        public string Redirect {
            get {
                var redirect = this.As<InfosetPart>().Get<SEOSettingsPart>("Redirect");

                if (!string.IsNullOrEmpty(redirect))
                    return redirect;

                if (RedirectToNonWWW)
                    return "RedirectToNonWWW";

                return redirect;
            }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("Redirect", value.ToString()); }
        }

        public bool RedirectToNonWWW {
            get {
                var attributeValue = this.As<InfosetPart>().Get<SEOSettingsPart>("RedirectToNonWWW");
                return !string.IsNullOrWhiteSpace(attributeValue) && Convert.ToBoolean(attributeValue);
            }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("RedirectToNonWWW", value.ToString()); }
        }

        public string IgnoredUrls
        {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("IgnoredUrls"); }
            set { this.As<InfosetPart>().Set<SEOSettingsPart>("IgnoredUrls", value == null ? "" : value.ToString()); }
        }

        public string Robots {
            get { return this.As<InfosetPart>().Get<SEOSettingsPart>("Robots"); }
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