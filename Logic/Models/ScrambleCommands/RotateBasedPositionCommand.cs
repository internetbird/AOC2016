using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    /* rotate based on position of letter x */
    public class RotateBasedPositionCommand : ScrambleCommandBase
    {
        public RotateBasedPositionCommand(object[] parameters) : base(parameters)
        {
        }

        public override string Execute(string input)
        {
            int basedIndex = input.IndexOf((char)_parameters[0]);
            int rotateAmount = basedIndex + 1;
            if(basedIndex >= 4)
            {
                rotateAmount++;
            }
            return input.ShiftRight(rotateAmount);
        }
    }
}
