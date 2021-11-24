using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models.ScrambleCommands
{
    /* move position x to position y */
    public class MovePositionCommand : ScrambleCommandBase
    {
        public MovePositionCommand(object[] parameters) : base(parameters)
        {
        }
        public override string Execute(string input)
        {
            string result = input.ChangeIndex((int)_parameters[0], (int)_parameters[1]);
            return result;
        }

        public override string Undo(string input)
        {
            string result = input.ChangeIndex((int)_parameters[1], (int)_parameters[0]);
            return result;
        }
    }
}
