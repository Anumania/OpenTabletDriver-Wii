using OpenTabletDriver.Configurations.Parsers.Huion;
using OpenTabletDriver.Configurations.Parsers.UCLogic;
using OpenTabletDriver.Plugin.Tablet;

namespace OpenTabletDriver.Configurations.Parsers
{
    public class WiiReportParser : TabletReportParser
    {
        public override IDeviceReport Parse(byte[] data)
        {
            if (data[0] == 0x37)
                return new WiiReport(data);
            return new WiiReport(new byte[22]);
        }
    }
}
