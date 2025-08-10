using OpenTabletDriver.Configurations.Parsers.Huion;
using OpenTabletDriver.Configurations.Parsers.UCLogic;
using OpenTabletDriver.Plugin.Tablet;

namespace OpenTabletDriver.Configurations.Parsers
{
    public class WiiReportParser : TabletReportParser
    {
        public override IDeviceReport Parse(byte[] data)
        {
            //get the quadrant out. if the quadrant is too big, assume no pen is detected, so dont give a pen reading.
            if (data[0] == 0x37 && data[18] != 255)
                return new WiiReport(data);
            return (new PassthroughReportParser()).Parse(data);
        }
    }
}
