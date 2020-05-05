namespace MicroWiki.DAL.Migrations
{
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration : DbMigrationsConfiguration<MicroWiki.DAL.Entities.WikiContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = false;
            ContextKey = "MigrationApp.Models.WikiContext";
        }

        protected override void Seed(MicroWiki.DAL.Entities.WikiContext context)
        {
           
        }
    }
}
