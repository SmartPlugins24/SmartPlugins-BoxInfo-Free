﻿using System.Collections.Generic;
using System.Web.Mvc;
using SmartStore.Web.Framework;
﻿using SmartStore.Web.Framework.Modelling;
using System.ComponentModel.DataAnnotations;
using System;
using SmartStore.Services.Localization;
using SmartStore.Web.Framework.Localization;

namespace SmartPlugins.BoxInfo.Models
{
    public class BoxInfoModel : EntityModelBase, ILocalizedModel<BoxInfoLocalizedModel>
	{

        public BoxInfoModel()
        {
			EnableInfoBoxOne = false;
			EnableInfoBoxTwo = false;
			EnableInfoBoxThree = false;
			EnableInfoBoxFour = false;
			EnableInfoBoxFive = false;
			InfoBoxOneUrl = string.Empty;
			InfoBoxTwoUrl = string.Empty;
			InfoBoxThreeUrl = string.Empty;
			InfoBoxFourUrl = string.Empty;
			InfoBoxFiveUrl = string.Empty;
			InfoBoxOneTitle = "";
			InfoBoxOneText = "";
			InfoBoxOneImageId = 0;
			Locales = new List<BoxInfoLocalizedModel>();
		}

        [SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.EnableInfoBox")]
		public bool EnableInfoBoxOne { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.EnableInfoBox")]
		public bool EnableInfoBoxTwo { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.EnableInfoBox")]
		public bool EnableInfoBoxThree { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.EnableInfoBox")]
		public bool EnableInfoBoxFour { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.EnableInfoBox")]
		public bool EnableInfoBoxFive { get; set; }

		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxUrl")]
		public string InfoBoxOneUrl { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxUrl")]
		public string InfoBoxTwoUrl { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxUrl")]
		public string InfoBoxThreeUrl { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxUrl")]
		public string InfoBoxFourUrl { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxUrl")]
		public string InfoBoxFiveUrl { get; set; }

		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxTitle")]
		public  string InfoBoxOneTitle { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxTitle")]
		public string InfoBoxTwoTitle { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxTitle")]
		public string InfoBoxThreeTitle { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxTitle")]
		public string InfoBoxFourTitle { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxTitle")]
		public string InfoBoxFiveTitle { get; set; }

		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxText")]
		public string InfoBoxOneText { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxText")]
		public string InfoBoxTwoText { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxText")]
		public string InfoBoxThreeText { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxText")]
		public string InfoBoxFourText { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxText")]
		public string InfoBoxFiveText { get; set; }

		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxImageId")]
        [UIHint("Media"), AdditionalMetadata("album", "content")]
        public int InfoBoxOneImageId { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxImageId")]
        [UIHint("Media"), AdditionalMetadata("album", "content")]
        public int InfoBoxTwoImageId { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxImageId")]
        [UIHint("Media"), AdditionalMetadata("album", "content")]
        public int InfoBoxThreeImageId { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxImageId")]
        [UIHint("Media"), AdditionalMetadata("album", "content")]
        public int InfoBoxFourImageId { get; set; }
		[SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.InfoBoxImageId")]
        [UIHint("Media"), AdditionalMetadata("album", "content")]
        public int InfoBoxFiveImageId { get; set; }

        [SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.WidgetZone")]
        public string WidgetZone { get; set; }
        [SmartResourceDisplayName("Plugins.SmartPlugins.BoxInfo.Fields.WidgetZone")]
        public List<SelectListItem> AvailableWidgetZone { get; set; }
        public IList<BoxInfoLocalizedModel> Locales { get; set; }
	}

	public class BoxInfoLocalizedModel : ILocalizedModelLocal
	{
		public int LanguageId { get; set; }
		
		public string InfoBoxOneTitle { get; set; }
		public string InfoBoxTwoTitle { get; set; }
		public string InfoBoxThreeTitle { get; set; }
		public string InfoBoxFourTitle { get; set; }
		public string InfoBoxFiveTitle { get; set; }
			   
		public string InfoBoxOneText { get; set; }
		public string InfoBoxTwoText { get; set; }
		public string InfoBoxThreeText { get; set; }
		public string InfoBoxFourText { get; set; }
		public string InfoBoxFiveText { get; set; }
	}
}