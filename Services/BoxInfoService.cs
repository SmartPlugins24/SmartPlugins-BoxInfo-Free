using System;
using System.Collections.Generic;
using System.Globalization;
using System.IO;
using System.Linq;
using System.Text;
using SmartStore.Core.Data;
using SmartStore.Core.Domain.Catalog;
using SmartStore.Core.Localization;
using SmartStore.Core.Plugins;
using SmartPlugins.BoxInfo.Domain;
using SmartPlugins.BoxInfo.Models;
using SmartStore.Services;
using SmartStore;

namespace SmartPlugins.BoxInfo.Services
{
    public partial class BoxInfoService : IBoxInfoService
	{

        private readonly IRepository<BoxInfoRecord> _sRepository;
		private readonly ICommonServices _services;
		private readonly IPluginFinder _pluginFinder;

		public BoxInfoService(
			IRepository<BoxInfoRecord> sRepository,
			ICommonServices services,
			IPluginFinder pluginFinder)
        {
            _sRepository = sRepository;
			_services = services;
			_pluginFinder = pluginFinder;

			T = NullLocalizer.Instance;
        }

		public Localizer T { get; set; }

     public BoxInfoRecord GetBoxInfoRecordById(int id)
        {
            if (id == 0)
                return null;

            var query = 
				from gp in _sRepository.Table
				where gp.Id == id
				select gp;

            var record = query.FirstOrDefault();
            return record;
        }
      
        public List<BoxInfoRecord> GetBoxInfoRecords()
		{
            var lst = _sRepository.Get().ToList();
			return lst;
		}

        public void InsertBoxInfoRecord(BoxInfoRecord record)
        {
            if (record == null)
                throw new ArgumentNullException("BoxInfoRecord");

            _sRepository.Insert(record);
        }

		public void UpdateBoxInfoRecord(BoxInfoRecord record)
        {
			if (record == null)
				throw new ArgumentNullException("record");

			_sRepository.Update(record);
        }

		public void DeleteBoxInfoRecord(BoxInfoRecord record)
		{
			if (record == null)
				throw new ArgumentNullException("record");

			_sRepository.Delete(record);
		}

		public BoxInfoRecord GetBoxInfoRecord()
		{
			var query =
			  from gp in _sRepository.Table
			  select gp;

			var record = query.FirstOrDefault();
			return record;
		}

	
	}
}
