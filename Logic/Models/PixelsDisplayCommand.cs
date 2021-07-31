using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class PixelsDisplayCommand
    {
        public PixelsDisplayCommandType Type { get; set; }
        public int CommandValue1 { get; set; }
        public int CommandValue2 { get; set; }
    }
}
