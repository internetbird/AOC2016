using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    /* rotate right/left x steps */
    public class RotateCommand : ScrambleCommandBase
    {
        public RotateCommand(object[] parameters) : base(parameters)
        {
        }

        public override string Execute(string input)
        {
            string result = input;

            if ((string)_parameters[0] == "right")
            {
                result = input.ShiftRight((int)_parameters[1]);
            } else
            {
                result = input.ShiftLeft((int)_parameters[1]);
            }
            return result;
        }

        public override string Undo(string input)
        {
            string result = input;

            if ((string)_parameters[0] == "right")
            {
                result = input.ShiftLeft((int)_parameters[1]);
            }
            else
            {
                result = input.ShiftRight((int)_parameters[1]);
            }
            return result;
        }
    }
}
