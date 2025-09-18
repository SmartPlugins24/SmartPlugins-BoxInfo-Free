
using SmartStore.Core.Configuration;

namespace SmartPlugins.BoxInfo
{
    public class BoxInfoSettings : ISettings
    {
        public BoxInfoSettings()
        {
            WidgetZone = "main_column_before";
        }
        public string WidgetZone { get; set; }

    }
}