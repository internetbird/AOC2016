using BirdLib;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    /*reverse positions x through y*/
    public class ReversePositionCommand : ScrambleCommandBase
    {
        public ReversePositionCommand(object[] parameters) : base(parameters)
        {
        }

        public override string Execute(string input)
        {
            string result = input.ReversePart((int)_parameters[0], (int)_parameters[1]);
            return result;
        }

        public override string Undo(string input)
        {
            string result = input.ReversePart((int)_parameters[0], (int)_parameters[1]);
            return result;
        }
    }
}
