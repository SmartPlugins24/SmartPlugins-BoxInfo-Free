using System.Data.Entity.ModelConfiguration;
using SmartPlugins.BoxInfo.Domain;

namespace SmartPlugins.BoxInfo.Data
{
	public partial class BoxInfoRecordMap : EntityTypeConfiguration<BoxInfoRecord>
	{
		public BoxInfoRecordMap()
		{
			this.ToTable("BoxInfo");
			this.HasKey(x => x.Id);

		}
	}
}
  