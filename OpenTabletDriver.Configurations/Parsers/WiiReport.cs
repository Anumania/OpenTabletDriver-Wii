using System;
using System.Numerics;
using System.Runtime.CompilerServices;
using OpenTabletDriver.Plugin.Tablet;
using static System.Runtime.InteropServices.JavaScript.JSType;

namespace OpenTabletDriver.Configurations.Parsers
{
    public struct WiiReport : ITabletReport, IAuxReport
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

            Pressure = (uint)(buff[offset + 3] - 8) ; //pressure seems to max at 485
            if ((buff[offset + 5] & 4) != 0)
            {
                Pressure += 255;
            }

            PenButtons = new bool[]
            {
               (buff[offset + 5] & 1) == 0,
               (buff[offset + 5] & 2) == 0
            };

            AuxButtons = new bool[]
            {
                (buff[1] & 1) != 0, //left
                (buff[1] & 2) != 0, //right
                (buff[1] & 4) != 0, //down
                (buff[1] & 8) != 0, //up
                (buff[1] & 16) != 0, //plus
                //(buff[1] & 32) != 0, //who fucken knows what these are
                //(buff[1] & 64) != 0,
                //(buff[2] & 128) != 0, //nothing
                (buff[2] & 1) != 0, // 2
                (buff[2] & 2) != 0, // 1
                (buff[2] & 4) != 0, //b
                (buff[2] & 8) != 0, //a
                (buff[2] & 16) != 0, //-
                //(buff[1] & 32) != 0, //who fucken knows what these are
                //(buff[1] & 64) != 0,
                //(buff[2] & 128) != 0,
            };

        }

        public byte[] Raw { set; get; }
        public Vector2 Position { set; get; }
        public uint Pressure { set; get; }
        public bool[] PenButtons { set; get; }
        public bool[] AuxButtons { set; get; }
    }
}
