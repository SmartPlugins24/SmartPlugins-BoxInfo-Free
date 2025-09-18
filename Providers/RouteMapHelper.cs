using SmartStore;
using SmartStore.Core.Infrastructure;
using SmartStore.Core.IO;
using SmartStore.Core.Themes;
using SmartStore.Utilities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.Mvc;

namespace SmartPlugins.BoxInfo.Providers
{
	public class RouteMapHelper
	{
		public RouteMapHelper()
		{
		}
		public static string GetRouteThemeable(ControllerContext controllerContext,string partialViewName)
		{
			Guard.NotNull(controllerContext, nameof(controllerContext));
			Guard.NotEmpty(partialViewName, nameof(partialViewName));
			var theme = EngineContext.Current.Resolve<IThemeContext>().CurrentTheme;
			var fileSystem = EngineContext.Current.Resolve<IFileSystem>();
			var themeName = theme.ThemeName;
			var controllerName = controllerContext.RouteData.GetRequiredString("controller");
			var areaName = controllerContext.RouteData.GetAreaName();

			var areaThemeFormats = "Themes/{3}/Views/{2}/{1}/{0}";
			var path1 = areaThemeFormats.FormatInvariant("Partials",controllerName, areaName, themeName) + "/" + partialViewName + ".cshtml";
			var path2 = areaThemeFormats.FormatInvariant(partialViewName, controllerName, areaName, themeName) + ".cshtml";
			var existspath1 = fileSystem.FileExists(path1);
			if (existspath1)
			{
				return path1.EnsureStartsWith("~/");
			}
			var existspath2 = fileSystem.FileExists(path2);
			if (existspath2)
			{
				return path2.EnsureStartsWith("~/");
			}
			return "";
		}
	}
}