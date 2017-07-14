using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;
using Orchard.Environment.Extensions;

namespace Moov2.Orchard.SEO
{
    [OrchardFeature("Moov2.Orchard.SEO.Redirects")]
    public class RedirectMigrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("RedirectPartRecord",
                table => table
                    .ContentPartVersionRecord()
                    .Column<string>("RedirectTo", column => column.WithLength(500).WithDefault(""))
                );

            ContentDefinitionManager.AlterPartDefinition("RedirectPart", builder => builder
                .WithDescription("Stores information about the Redirect content type."));

            ContentDefinitionManager.AlterTypeDefinition("Redirect",
                cfg => cfg
                    .WithPart("RedirectPart")
                    .WithPart("CommonPart", p => p
                        .WithSetting("DateEditorSettings.ShowDateEditor", "True"))
                    .WithPart("AutoroutePart", builder => builder
                        .WithSetting("AutorouteSettings.AllowCustomPattern", "True")
                        .WithSetting("AutorouteSettings.AutomaticAdjustmentOnEdit", "False"))
                    .Creatable()
                    .Listable()
                    .Securable()
                );

            return 1;
        }
    }
}