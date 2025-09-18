using System.Collections.Generic;
using System.Web.Routing;
using SmartStore.Core.Plugins;
using SmartStore.Services.Cms;
using SmartStore.Services.Configuration;
using SmartStore.Services.Localization;
using SmartStore.Web.Models.Catalog;

namespace SmartPlugins.BoxInfo
{
    /// <summary>
    /// Google Analytics Plugin
    /// </summary>
	public class BoxInfoPlugin : BasePlugin,  IConfigurable
    {
        private readonly ILocalizationService _localizationService;
        private readonly ISettingService _settingService;
        public BoxInfoPlugin(ILocalizationService localizationService, ISettingService settingService)
        {
            _localizationService = localizationService;
            _settingService = settingService;
        }



        /// <summary>
        /// Gets a route for provider configuration
        /// </summary>
        /// <param name="actionName">Action name</param>
        /// <param name="controllerName">Controller name</param>
        /// <param name="routeValues">Route values</param>
        public void GetConfigurationRoute(out string actionName, out string controllerName, out RouteValueDictionary routeValues)
        {
            actionName = "Configure";
            controllerName = "BoxInfo";
			routeValues = new RouteValueDictionary() { { "area", "SmartPlugins.BoxInfo" } };
        }

        public static string SystemName
        {
            get { return "SmartPlugins.BoxInfo"; }
        }

        /// <summary>
        /// Install plugin
        /// </summary>
        public override void Install()
        {
            var settings = new BoxInfoSettings();

            _settingService.SaveSetting(settings);
            _localizationService.ImportPluginResourcesFromXml(this.PluginDescriptor);
            
            base.Install();
        }

        /// <summary>
        /// Uninstall plugin
        /// </summary>
        public override void Uninstall()
        {
            //locales
            _localizationService.DeleteLocaleStringResources(this.PluginDescriptor.ResourceRootKey);
            _localizationService.DeleteLocaleStringResources("Plugins.FriendlyName.SmartPlugins.BoxInfo", false);

            _settingService.DeleteSetting<BoxInfoSettings>();
            base.Uninstall();
        }
    }
}
