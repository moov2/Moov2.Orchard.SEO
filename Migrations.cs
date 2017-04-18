using Orchard.ContentManagement.MetaData;
using Orchard.Core.Contents.Extensions;
using Orchard.Data.Migration;

namespace Moov2.Orchard.SEO
{
    public class Migrations : DataMigrationImpl
    {
        public int Create()
        {
            SchemaBuilder.CreateTable("MetaInfoPartRecord",
                table => table
                    .ContentPartVersionRecord()
                    .Column<string>("Description", column => column.WithLength(500).WithDefault(""))
                    .Column<string>("Keywords", column => column.WithLength(500).WithDefault(""))
                );

            ContentDefinitionManager.AlterPartDefinition("MetaInfoPart", builder => builder
                .Attachable()
                .WithDescription("Add meta description and keywords for page"));

            return 1;
        }
    }
}