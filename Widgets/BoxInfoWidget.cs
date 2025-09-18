using System.Collections.Generic;
using System.Web;
using System.Web.Routing;

using SmartStore.Services.Cms;
using SmartStore.Core.Plugins;
using System;

namespace PineStore.ContentSlider.Widgets
{
	[SystemName("SmartPlugins.BoxInfo")]
	public class BoxInfoWidget : IWidget
	{
		private readonly HttpContextBase _httpContext;

		public BoxInfoWidget(HttpContextBase httpContext)
		{
			_httpContext = httpContext;
		}

		public IList<string> GetWidgetZones()
		{
			return new List<string>()
			{
                "content_before",
                "main_column_before",
                "home_page_top",
                "home_page_after_intro",
                "home_page_after_categories",
                "home_page_after_products",
                "home_page_after_bestsellers",
                "home_page_after_manufacturers",
                "home_page_after_tags",
                "home_page_after_news",
                "home_page_after_polls",
                "home_page_bottom",
                "main_column_after",
                "content_after",
            };
		}

		public void GetDisplayWidgetRoute(string widgetZone, object model, int storeId, out string actionName, out string controllerName, out RouteValueDictionary routeValues)
		{
			actionName = "PublicInfo";
			controllerName = "BoxInfo";
			routeValues = new RouteValueDictionary()
			{
				{"area", "SmartPlugins.BoxInfo"},
				{"widgetZone", widgetZone}
			};
		}
	}
}