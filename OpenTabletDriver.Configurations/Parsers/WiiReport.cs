using System.Numerics;
using System.Runtime.CompilerServices;
using OpenTabletDriver.Tablet;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpenTabletDriver.Configurations.Parsers
{
    public struct WiiReport : ITabletReport
    {
        internal WiiReport(byte[] report)
        {
            Raw = report;

            byte[] buff = report;
            int offset = 16;
            int x = ((buff[offset + 2] % 16) * 255) + buff[offset];
            int y = (buff[offset + 2] / 16) * 255;
            y += buff[offset + 1];

            x -= 200;
            double _x = x * 1.05;
            x = (int)_x;

            y = 1400 - y;

            double _y = y * 1.4;

            y = (int)_y;

            Position = new Vector2
            {
                X = x,
                Y = y
            };

            Pressure = (uint)(buff[offset + 3] - 8);

            PenButtons = new bool[]
            {
               (buff[offset + 5] & 1) == 0,
               (buff[offset + 5] & 2) == 0
            }; 
        }

        public byte[] Raw { set; get; }
        public Vector2 Position { set; get; }
        public uint Pressure { set; get; }
        public bool[] PenButtons { set; get; }
    }
}
