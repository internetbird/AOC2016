using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    public interface IScrambleCommand
    {
        public string Execute(string input);
    }
}
