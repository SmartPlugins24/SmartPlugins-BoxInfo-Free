using System.Web.Mvc;
using System.Web.Routing;
using SmartStore.Web.Framework.Routing;

namespace SmartPlugins.BoxInfo
{
    public partial class RouteProvider : IRouteProvider
    {
          public void RegisterRoutes(RouteCollection routes)
        {
            routes.MapRoute("SmartPlugins.BoxInfo",
				 "Plugins/SmartPlugins.BoxInfo/{action}",
                 new { controller = "BoxInfo", action = "Configure" },
                 new[] { "SmartPlugins.BoxInfo.Controllers" }
            )
			.DataTokens["area"] = "SmartPlugins.BoxInfo";
        }

        public int Priority
        {
            get
            {
                return 2;
            }
        }
    }
}
