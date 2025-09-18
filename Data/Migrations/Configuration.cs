namespace SmartPlugins.BoxInfo.Data.Migrations
{
    using SmartStore.Core.Data;
    using SmartStore.Data;
    using SmartStore.Data.Setup;
    using System;
    using System.Data.Entity;
    using System.Data.Entity.Migrations;
    using System.Linq;

    internal sealed class Configuration :  DbMigrationsConfiguration<BoxInfoObjectContext>
    {
        public Configuration()
        {
            AutomaticMigrationsEnabled = true;
            MigrationsDirectory = @"Data\Migrations";
            ContextKey = "PineStore.BoxInfo"; // DO NOT CHANGE!
        }

        protected override void Seed(BoxInfoObjectContext context)
        {
         
        
        }
       

    }
}
