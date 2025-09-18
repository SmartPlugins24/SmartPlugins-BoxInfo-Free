using System;
using System.Collections.Generic;
using System.Data.Entity;
using System.Data.Entity.Infrastructure;
using System.Linq;
using SmartPlugins.BoxInfo.Domain;
using SmartStore.Core;
using SmartStore.Data;
using SmartStore.Data.Setup;
using SmartPlugins.BoxInfo.Data.Migrations;

namespace SmartPlugins.BoxInfo.Data
{

	public class BoxInfoObjectContext : ObjectContextBase
	{
        public const string ALIASKEY = "sm_object_context_content_Box_Info";

		static BoxInfoObjectContext()
		{
			var initializer = new MigrateDatabaseInitializer<BoxInfoObjectContext, Configuration>
			{
				TablesToCheck = new[] { "BoxInfo" }
			};
			Database.SetInitializer(initializer);
		}

		/// <summary>
		/// For tooling support, e.g. EF Migrations
		/// </summary>
		public BoxInfoObjectContext()
			: base()
		{
		}

        public BoxInfoObjectContext(string nameOrConnectionString)
            : base(nameOrConnectionString, ALIASKEY) 
		{
		}
       // public DbSet<GoogleProductRecord> GoogleProductRecords { get; set; }

		protected override void OnModelCreating(DbModelBuilder modelBuilder)
		{
			modelBuilder.Configurations.Add(new BoxInfoRecordMap());
            base.OnModelCreating(modelBuilder);
		}

	}
}