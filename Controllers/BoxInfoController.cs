using System.Web.Mvc;
using SmartStore.Core;
using SmartStore.Services.Configuration;
using SmartStore.Services.Stores;
using SmartStore.Web.Framework.Controllers;
using SmartStore.Web.Framework.Security;
using SmartStore.Web.Framework.Settings;
using SmartStore.Services;
using SmartStore.Web.Framework.Theming;
using SmartPlugins.BoxInfo.Models;
using SmartStore.Services.Localization;
using SmartPlugins.BoxInfo.Domain;
using SmartPlugins.BoxInfo.Services;
using System;
using SmartStore.Services.Media;
using SmartPlugins.BoxInfo.Providers;
using SmartStore;
using System.Collections.Generic;

namespace SmartPlugins.BoxInfo.Controllers
{
    public class BoxInfoController : AdminControllerBase
	{
        private readonly IWorkContext _workContext;
        private readonly IStoreService _storeService;
        private readonly ICommonServices _services;
        private readonly ISettingService _settingService;
		private readonly ILocalizedEntityService _localizedEntityService;
		private readonly ILanguageService _languageService;
		private readonly IBoxInfoService _boxInfoService;
		private readonly IMediaService _mediaService;
		public BoxInfoController(IWorkContext workContext,ICommonServices services,
			ISettingService settingService, IStoreService storeService,
			 ILocalizedEntityService localizedEntityService, ILanguageService languageService,
			 IBoxInfoService boxInfoService, IMediaService mediaService)
        {
            this._workContext = workContext;
            _services = services;
            _settingService = settingService;
            _storeService = storeService;
			_localizedEntityService = localizedEntityService;
			_languageService = languageService;
			_boxInfoService = boxInfoService;
			_mediaService = mediaService;
		}
		[NonAction]
		public void UpdateLocales(BoxInfoRecord record, BoxInfoModel model)
		{
			foreach (var localized in model.Locales)
			{

				_localizedEntityService.SaveLocalizedValue(record,
										   x => x.InfoBoxOneTitle,
										   localized.InfoBoxOneTitle,
										   localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
										   x => x.InfoBoxTwoTitle,
										   localized.InfoBoxTwoTitle,
										   localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
										   x => x.InfoBoxThreeTitle,
										   localized.InfoBoxThreeTitle,
										   localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
										   x => x.InfoBoxFourTitle,
										   localized.InfoBoxFourTitle,
										   localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
										   x => x.InfoBoxFiveTitle,
										   localized.InfoBoxFiveTitle,
										   localized.LanguageId);

				_localizedEntityService.SaveLocalizedValue(record,
										   x => x.InfoBoxOneText,
										   localized.InfoBoxOneText,
										   localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
											x => x.InfoBoxTwoText,
											localized.InfoBoxTwoText,
											localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
											x => x.InfoBoxThreeText,
											localized.InfoBoxThreeText,
											localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
											x => x.InfoBoxFourText,
											localized.InfoBoxFourText,
											localized.LanguageId);
				_localizedEntityService.SaveLocalizedValue(record,
											 x => x.InfoBoxFiveText,
											 localized.InfoBoxFiveText,
											 localized.LanguageId);
			}
		}

        [AdminAuthorize,ChildActionOnly, LoadSetting]
        public ActionResult Configure(BoxInfoSettings settings)
        {
            var model = new BoxInfoModel();
			var record=_boxInfoService.GetBoxInfoRecord();


			if (record==null)
			{
				//locales
				AddLocales(_languageService, model.Locales);
			}
			else
			{
				AddLocales(_languageService, model.Locales, (locale, languageId) =>
				{
					locale.InfoBoxOneTitle = record.GetLocalized(x => x.InfoBoxOneTitle, languageId, false, true);
					locale.InfoBoxTwoTitle = record.GetLocalized(x => x.InfoBoxTwoTitle, languageId, false, true);
					locale.InfoBoxThreeTitle = record.GetLocalized(x => x.InfoBoxThreeTitle, languageId, false, true);
					locale.InfoBoxFourTitle = record.GetLocalized(x => x.InfoBoxFourTitle, languageId, false, true);
					locale.InfoBoxFiveTitle = record.GetLocalized(x => x.InfoBoxFiveTitle, languageId, false, true);

					locale.InfoBoxOneText = record.GetLocalized(x => x.InfoBoxOneText, languageId, false, true);
					locale.InfoBoxTwoText = record.GetLocalized(x => x.InfoBoxTwoText, languageId, false, true);
					locale.InfoBoxThreeText = record.GetLocalized(x => x.InfoBoxThreeText, languageId, false, true);
					locale.InfoBoxFourText = record.GetLocalized(x => x.InfoBoxFourText, languageId, false, true);
					locale.InfoBoxFiveText = record.GetLocalized(x => x.InfoBoxFiveText, languageId, false, true);
				
				});
				UpdateRecordToModel(model, record);
			}

            model.WidgetZone = settings.WidgetZone;
            model.AvailableWidgetZone = AvailableWidgetZone(model.WidgetZone);

            return View(model);
        }
   
        [HttpPost]
        [AdminAuthorize]
        [ChildActionOnly]
		[ValidateInput(false)]
        public ActionResult Configure(BoxInfoModel model, FormCollection form)
        {
			ModelState.Clear();
			if (ModelState.IsValid)
			{
				var record = _boxInfoService.GetBoxInfoRecord();

				if (record==null)
				{
					 _boxInfoService.InsertBoxInfoRecord(new BoxInfoRecord());
					record = _boxInfoService.GetBoxInfoRecord();
				}
				UpdateModelToRecord(model, record);
				_boxInfoService.UpdateBoxInfoRecord(record);
				UpdateLocales(record,model);
			}

            var storeDependingSettingHelper = new StoreDependingSettingHelper(ViewData);
            var storeScope = this.GetActiveStoreScopeConfiguration(Services.StoreService, Services.WorkContext);
            var settings = Services.Settings.LoadSetting<BoxInfoSettings>(storeScope);

            settings.WidgetZone = model.WidgetZone;

            using (Services.Settings.BeginScope())
            {
                storeDependingSettingHelper.UpdateSettings(settings, form, storeScope, Services.Settings);
            }

            using (Services.Settings.BeginScope())
            {
                _settingService.SaveSetting(settings, x => x.WidgetZone, 0, false);
            }

            return RedirectToConfiguration(BoxInfoPlugin.SystemName);
        }
		[ChildActionOnly]
		public ActionResult PublicInfo(string widgetZone)
		{
           
            var routeData = ((System.Web.UI.Page)this.HttpContext.CurrentHandler).RouteData;
			if ((routeData.Values["controller"].ToString().Equals("home", StringComparison.InvariantCultureIgnoreCase)
				&& routeData.Values["action"].ToString().Equals("index", StringComparison.InvariantCultureIgnoreCase)))
			{
                var setting = _settingService.LoadSetting<BoxInfoSettings>();
                if (!widgetZone.Equals(setting.WidgetZone, StringComparison.InvariantCultureIgnoreCase))
                {
                    return Content("");
                }

                var record=	_boxInfoService.GetBoxInfoRecord();
				var model=new BoxInfoViewModel();
				if (record !=null)
				{
                    model.EnableInfoBoxOne = record.EnableInfoBoxOne;
					model.EnableInfoBoxTwo = record.EnableInfoBoxTwo;
					model.EnableInfoBoxThree = record.EnableInfoBoxThree;
					model.EnableInfoBoxFour = record.EnableInfoBoxFour;
					model.EnableInfoBoxFive = record.EnableInfoBoxFive;

					model.InfoBoxOneUrl = record.InfoBoxOneUrl;
					model.InfoBoxTwoUrl = record.InfoBoxTwoUrl;
					model.InfoBoxThreeUrl = record.InfoBoxThreeUrl;
					model.InfoBoxFourUrl = record.InfoBoxFourUrl;
					model.InfoBoxFiveUrl = record.InfoBoxFiveUrl;

					model.InfoBoxOneText = record.GetLocalized(x => x.InfoBoxOneText);
					model.InfoBoxTwoText = record.GetLocalized(x => x.InfoBoxTwoText);
					model.InfoBoxThreeText = record.GetLocalized(x => x.InfoBoxThreeText);
					model.InfoBoxFourText = record.GetLocalized(x => x.InfoBoxFourText);
					model.InfoBoxFiveText = record.GetLocalized(x => x.InfoBoxFiveText);

					model.InfoBoxOneTitle = record.GetLocalized(x => x.InfoBoxOneTitle);
					model.InfoBoxTwoTitle = record.GetLocalized(x => x.InfoBoxTwoTitle);
					model.InfoBoxThreeTitle = record.GetLocalized(x => x.InfoBoxThreeTitle);
					model.InfoBoxFourTitle = record.GetLocalized(x => x.InfoBoxFourTitle);
					model.InfoBoxFiveTitle = record.GetLocalized(x => x.InfoBoxFiveTitle);

					model.InfoBoxOneImageId = record.InfoBoxOneImageId;
					model.InfoBoxTwoImageId = record.InfoBoxTwoImageId;
					model.InfoBoxThreeImageId = record.InfoBoxThreeImageId;
					model.InfoBoxFourImageId = record.InfoBoxFourImageId;
					model.InfoBoxFiveImageId = record.InfoBoxFiveImageId;

					model.InfoBoxOneImageUrl = _mediaService.GetUrl(record.InfoBoxOneImageId,0);
					model.InfoBoxTwoImageUrl = _mediaService.GetUrl(record.InfoBoxTwoImageId,0);
					model.InfoBoxThreeImageUrl = _mediaService.GetUrl(record.InfoBoxThreeImageId,0);
					model.InfoBoxFourImageUrl = _mediaService.GetUrl(record.InfoBoxFourImageId,0);
					model.InfoBoxFiveImageUrl = _mediaService.GetUrl(record.InfoBoxFiveImageId,0);
				}
				
				if (!model.EnableInfoBoxOne &
					!model.EnableInfoBoxTwo &
					!model.EnableInfoBoxThree &
					!model.EnableInfoBoxFour &
					!model.EnableInfoBoxFive)
				{
					return Content("");
				}

				var pathTheme = RouteMapHelper.GetRouteThemeable(ControllerContext, "PublicInfo");
				if (!pathTheme.IsEmpty())
				{
					return View(pathTheme, model);
				}

				return View(model);

			}
			return Content("");
		}
		[NonAction]
		protected void UpdateModelToRecord(BoxInfoModel model, BoxInfoRecord Record)
		{
			var c = Record;
			var m = model;
			c.EnableInfoBoxFive = m.EnableInfoBoxFive;
			c.EnableInfoBoxFour = m.EnableInfoBoxFour;
			c.EnableInfoBoxOne = m.EnableInfoBoxOne;
			c.EnableInfoBoxThree = m.EnableInfoBoxThree;
			c.EnableInfoBoxTwo = m.EnableInfoBoxTwo;

			c.InfoBoxOneUrl = m.InfoBoxOneUrl;
			c.InfoBoxTwoUrl = m.InfoBoxTwoUrl;
			c.InfoBoxThreeUrl = m.InfoBoxThreeUrl;
			c.InfoBoxFourUrl = m.InfoBoxFourUrl;
			c.InfoBoxFiveUrl = m.InfoBoxFiveUrl;

			c.InfoBoxOneImageId = m.InfoBoxOneImageId;
			c.InfoBoxTwoImageId = m.InfoBoxTwoImageId;
			c.InfoBoxThreeImageId = m.InfoBoxThreeImageId;
			c.InfoBoxFourImageId = m.InfoBoxFourImageId;
			c.InfoBoxFiveImageId = m.InfoBoxFiveImageId;

			c.InfoBoxOneText = m.InfoBoxOneText;
			c.InfoBoxTwoText = m.InfoBoxTwoText;
			c.InfoBoxThreeText = m.InfoBoxThreeText;
			c.InfoBoxFourText = m.InfoBoxFourText;
			c.InfoBoxFiveText = m.InfoBoxFiveText;

			c.InfoBoxOneTitle = m.InfoBoxOneTitle;
			c.InfoBoxTwoTitle = m.InfoBoxTwoTitle;
			c.InfoBoxThreeTitle = m.InfoBoxThreeTitle;
			c.InfoBoxFourTitle = m.InfoBoxFourTitle;
			c.InfoBoxFiveTitle = m.InfoBoxFiveTitle;
			//c.Id = m.Id;
		}
		[NonAction]
		protected void UpdateRecordToModel(BoxInfoModel model, BoxInfoRecord Record)
		{
			var c = model;
			var m = Record;
			c.InfoBoxOneUrl = m.InfoBoxOneUrl;
			c.InfoBoxTwoUrl = m.InfoBoxTwoUrl;
			c.InfoBoxThreeUrl = m.InfoBoxThreeUrl;
			c.InfoBoxFourUrl = m.InfoBoxFourUrl;
			c.InfoBoxFiveUrl = m.InfoBoxFiveUrl;

			c.EnableInfoBoxFive = m.EnableInfoBoxFive;
			c.EnableInfoBoxFour = m.EnableInfoBoxFour;
			c.EnableInfoBoxOne = m.EnableInfoBoxOne;
			c.EnableInfoBoxThree = m.EnableInfoBoxThree;
			c.EnableInfoBoxTwo = m.EnableInfoBoxTwo;

			c.InfoBoxOneImageId = m.InfoBoxOneImageId;
			c.InfoBoxTwoImageId = m.InfoBoxTwoImageId;
			c.InfoBoxThreeImageId = m.InfoBoxThreeImageId;
			c.InfoBoxFourImageId = m.InfoBoxFourImageId;
			c.InfoBoxFiveImageId = m.InfoBoxFiveImageId;

			c.InfoBoxOneText = m.InfoBoxOneText;
			c.InfoBoxTwoText = m.InfoBoxTwoText;
			c.InfoBoxThreeText = m.InfoBoxThreeText;
			c.InfoBoxFourText = m.InfoBoxFourText;
			c.InfoBoxFiveText = m.InfoBoxFiveText;

			c.InfoBoxOneTitle = m.InfoBoxOneTitle;
			c.InfoBoxTwoTitle = m.InfoBoxTwoTitle;
			c.InfoBoxThreeTitle = m.InfoBoxThreeTitle;
			c.InfoBoxFourTitle = m.InfoBoxFourTitle;
			c.InfoBoxFiveTitle = m.InfoBoxFiveTitle;
			c.Id = m.Id;

            c.AvailableWidgetZone = AvailableWidgetZone();
		}


        private List<SelectListItem> AvailableWidgetZone(string sliderType = "main_column_before")
        {
            return new List<SelectListItem>() {
                    //new SelectListItem() { Text="content_before",Value="content_before", Selected=sliderType=="content_before" },
                    new SelectListItem() { Text="main_column_before",Value="main_column_before",Selected=sliderType=="main_column_before" },
                    new SelectListItem() { Text="home_page_top",Value="home_page_top",Selected=sliderType=="home_page_top" },
                    new SelectListItem() { Text="home_page_after_intro",Value="home_page_after_intro",Selected=sliderType=="home_page_after_intro" },
                    new SelectListItem() { Text="home_page_after_categories",Value="home_page_after_categories",Selected=sliderType=="home_page_after_categories" },
                    new SelectListItem() { Text="home_page_after_products",Value="home_page_after_products",Selected=sliderType=="home_page_after_products" },
                    new SelectListItem() { Text="home_page_after_bestsellers",Value="home_page_after_bestsellers",Selected=sliderType=="home_page_after_bestsellers" },
                    new SelectListItem() { Text="home_page_after_manufacturers",Value="home_page_after_manufacturers",Selected=sliderType=="home_page_after_manufacturers" },
                    new SelectListItem() { Text="home_page_after_tags",Value="home_page_after_tags",Selected=sliderType=="home_page_after_tags" },
                    new SelectListItem() { Text="home_page_after_news",Value="home_page_after_news",Selected=sliderType=="home_page_after_news" },
                    new SelectListItem() { Text="home_page_after_polls",Value="home_page_after_polls",Selected=sliderType=="home_page_after_polls" },
                    new SelectListItem() { Text="home_page_bottom",Value="home_page_bottom",Selected=sliderType=="home_page_bottom" },
                    new SelectListItem() { Text="main_column_after",Value="main_column_after",Selected=sliderType=="main_column_after" },
                    //new SelectListItem() { Text="content_after",Value="content_after",Selected=sliderType=="content_after" },
                };
        }
    }
}