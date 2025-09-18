using System;
using SmartStore.Core;
using System.ComponentModel.DataAnnotations;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using SmartStore.Core.Domain.Localization;

namespace SmartPlugins.BoxInfo.Domain
{
    /// <summary>
    /// Represents a Google product record
    /// </summary>
    public partial class BoxInfoRecord : BaseEntity, ILocalizedEntity
	{
		public BoxInfoRecord()
		{

            
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

		public int InfoBoxOneImageId { get; set; }
		public int InfoBoxTwoImageId { get; set; }
		public int InfoBoxThreeImageId { get; set; }
		public int InfoBoxFourImageId { get; set; }
		public int InfoBoxFiveImageId { get; set; }

    }
}