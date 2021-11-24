using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    /* 'swap position x with position y' */
    public class SwapPositionCommand : ScrambleCommandBase
    {
        public SwapPositionCommand(object[] parameters) : base(parameters)
        {
        }

        public override string Execute(string input)
        {
            string result = input.SwapIndexes((int)_parameters[0], (int)_parameters[1]);
            return result;
        }

        public override string Undo(string input)
        {
            string result = input.SwapIndexes((int)_parameters[1], (int)_parameters[0]);
            return result;
        }
    }
}
