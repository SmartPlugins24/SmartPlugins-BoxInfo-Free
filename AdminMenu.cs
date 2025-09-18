using SmartStore.Collections;
using SmartStore.Core.Localization;
using SmartStore.Web.Framework.UI;

namespace SmartPlugins.BoxInfo
{
    public class AdminMenu : AdminMenuProvider
    {
		public Localizer T { get; set; }
		public AdminMenu()
		{
			T = NullLocalizer.Instance;
		}
        protected override void BuildMenuCore(TreeNode<MenuItem> pluginsNode)
        {
            // BuildMenu.
            var menuItem = new MenuItem().ToBuilder()
                .Text("Box Info")
                .Icon("fa fa-boxes fa-fw")
                .ResKey("Plugins.FriendlyName.SmartPlugins.BoxInfo")
				.Action("ConfigurePlugin", "Plugin", new { systemName = BoxInfoPlugin.SystemName, area = "Admin" })
                .ToItem();

            pluginsNode.Prepend(menuItem);
        }

    }
}
