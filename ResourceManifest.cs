using Orchard.UI.Resources;

namespace Moov2.Orchard.Featured {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("FaviconEditor").SetUrl("favicon.editor.min.js", "favicon.editor.js").SetDependencies(new string [] { "JQuery", "jQueryColorBox" });
            manifest.DefineScript("OGImageEditor").SetUrl("ogimage.editor.min.js", "ogimage.editor.js").SetDependencies(new string[] { "JQuery", "jQueryColorBox" });
            manifest.DefineScript("TwitterImageEditor").SetUrl("twitterimage.editor.min.js", "twitterimage.editor.js").SetDependencies(new string[] { "JQuery", "jQueryColorBox" });
        }
    }
}