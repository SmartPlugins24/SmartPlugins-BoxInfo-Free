using System.Collections.Generic;
using SmartPlugins.BoxInfo.Domain;
using SmartPlugins.BoxInfo.Models;


namespace SmartPlugins.BoxInfo.Services
{
	public partial interface IBoxInfoService
	{
		BoxInfoRecord GetBoxInfoRecordById(int id);
		BoxInfoRecord GetBoxInfoRecord();
		List<BoxInfoRecord> GetBoxInfoRecords();

		void InsertBoxInfoRecord(BoxInfoRecord record);

		void UpdateBoxInfoRecord(BoxInfoRecord record);

		void DeleteBoxInfoRecord(BoxInfoRecord record);

		//void Upsert(int pk, string name, string value);

		//	GridModel<GoogleProductModel> GetGridModel(GridCommand command, string searchProductName = null, string touched = null);

		//string[] GetTaxonomyList();
	}
}
