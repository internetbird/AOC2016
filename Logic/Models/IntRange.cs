using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    internal class IntRange
    {
        public uint LowValue { get; set; }
        public uint HighValue { get; set; }


        public IntRange(uint lowValue, uint highValue)
        {
            LowValue = lowValue;
            HighValue = highValue;
        }

        public bool Contains(uint value)
        {
           return LowValue <= value && HighValue >= value;
        }

        internal uint GetRangeCount()
        {
            return HighValue - LowValue + 1;
        }
    }
}
