using System;
using SmartStore.Core;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SmartStore.Core.Domain.Localization;
using SmartStore.Services.Localization;

namespace SmartPlugins.BoxInfo.Models
{
    /// <summary>
    /// Represents a Google product record
    /// </summary>
    public partial class BoxInfoViewModel : BaseEntity, ILocalizedEntity
	{
		public BoxInfoViewModel()
		{

			EnableInfoBoxOne = false;
			EnableInfoBoxTwo = false;
			EnableInfoBoxThree = false;
			EnableInfoBoxFour = false;
			EnableInfoBoxFive = false;
		}
		public bool EnableInfoBoxOne { get; set; }
		public bool EnableInfoBoxTwo { get; set; }
		public bool EnableInfoBoxThree { get; set; }
		public bool EnableInfoBoxFour { get; set; }
		public bool EnableInfoBoxFive { get; set; }

		public string InfoBoxOneUrl { get; set; }
		public string InfoBoxTwoUrl { get; set; }
		public string InfoBoxThreeUrl { get; set; }
		public string InfoBoxFourUrl { get; set; }
		public string InfoBoxFiveUrl { get; set; }

		public LocalizedValue<string> InfoBoxOneTitle { get; set; }
		public LocalizedValue<string> InfoBoxTwoTitle { get; set; }
		public LocalizedValue<string> InfoBoxThreeTitle { get; set; }
		public LocalizedValue<string> InfoBoxFourTitle { get; set; }
		public LocalizedValue<string> InfoBoxFiveTitle { get; set; }

		public LocalizedValue<string> InfoBoxOneText { get; set; }
		public LocalizedValue<string> InfoBoxTwoText { get; set; }
		public LocalizedValue<string> InfoBoxThreeText { get; set; }
		public LocalizedValue<string> InfoBoxFourText { get; set; }
		public LocalizedValue<string> InfoBoxFiveText { get; set; }

		public int InfoBoxOneImageId { get; set; }
		public int InfoBoxTwoImageId { get; set; }
		public int InfoBoxThreeImageId { get; set; }
		public int InfoBoxFourImageId { get; set; }
		public int InfoBoxFiveImageId { get; set; }

		public string InfoBoxOneImageUrl { get; set; }
		public string InfoBoxTwoImageUrl { get; set; }
		public string InfoBoxThreeImageUrl { get; set; }
		public string InfoBoxFourImageUrl { get; set; }
		public string InfoBoxFiveImageUrl { get; set; }

	}
}