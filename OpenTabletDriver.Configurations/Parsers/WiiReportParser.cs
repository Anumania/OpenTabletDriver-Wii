using OpenTabletDriver.Configurations.Parsers.Huion;
using OpenTabletDriver.Configurations.Parsers.UCLogic;
using OpenTabletDriver.Tablet;

namespace OpenTabletDriver.Configurations.Parsers
{
    public class WiiReportParser : IReportParser<IDeviceReport>
    {
        public IDeviceReport Parse(byte[] data)
        {
            return new WiiReport(data);

        }
    }
}
