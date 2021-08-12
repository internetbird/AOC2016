using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class EasterBunnyComputerInstruction
    {
        public EasterBunnyComputerInstructionType Type { get; set; }
        public string Operand1 { get; set; }
        public string Operand2 { get; set; }
    }
}
