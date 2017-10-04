using Orchard.UI.Resources;

namespace Moov2.Orchard.Featured {
    public class ResourceManifest : IResourceManifestProvider {
        public void BuildManifests(ResourceManifestBuilder builder) {
            var manifest = builder.Add();
            manifest.DefineScript("FaviconEditor").SetUrl("favicon.editor.min.js", "favicon.editor.js").SetDependencies(new string [] { "JQuery", "jQueryColorBox" });
        }
    }
}