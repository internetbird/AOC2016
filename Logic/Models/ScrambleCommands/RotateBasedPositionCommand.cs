using AOC2016.Utility;
using BirdLib;
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
            if (basedIndex >= 4)
            {
                rotateAmount++;
            }
            return input.ShiftRight(rotateAmount);
        }

        public override string Undo(string input)
        {

            if (input.Length != 8)
            {
                throw new ArgumentException("This function assumes an input length of 8");
            }

            int rotateAmount = 0;

            int basedIndex = input.IndexOf((char)_parameters[0]);

            switch (basedIndex)
            {
                case 0:
                case 1:
                    rotateAmount = 1;
                    break;
                case 2:
                    rotateAmount = 6;
                    break;
                case 3:
                    rotateAmount = 2;
                    break;
                case 4:
                    rotateAmount = 7;
                    break;
                case 5:
                    rotateAmount = 3;
                    break;
                case 6:
                    rotateAmount = 0;
                    break;
                case 7:
                    rotateAmount = 4;
                    break;
            }

            return input.ShiftLeft(rotateAmount);
        }
    }
}
