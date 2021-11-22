using AOC2016.Logic.Models;
using AOC2016.Logic.Models.ScrambleCommands;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Builders
{
    public class ScrambleCommandBuilder
    {
        public IScrambleCommand BuildCommand(string commandText)
        {
            IScrambleCommand command = null;

            string[] commandParts = commandText.Split(' ');

            /* 'swap position x with position y' */
            if (commandText.StartsWith("swap position"))
            {
                var parameters = new object[]
                {
                    int.Parse(commandParts[2]),
                    int.Parse(commandParts[5])
                };

                command = new SwapPositionCommand(parameters);

            }
            else if (commandText.StartsWith("swap letter")) /*swap letter x with letter y*/
            {
                var parameters = new object[]
                {
                    commandParts[2][0],
                    commandParts[5][0]
                };

                command = new SwapLetterCommand(parameters);

            }
            else if (commandText.StartsWith("rotate right") || commandText.StartsWith("rotate left"))
            /* rotate right/left x steps */
            {
                var parameters = new object[]
                {
                    commandParts[1],
                    int.Parse(commandParts[2])
                };

                command = new RotateCommand(parameters);
            }
            else if (commandText.StartsWith("rotate based")) /* rotate based on position of letter x */
            {
                var parameters = new object[]
                {
                    commandParts[6][0]
                };

                command = new RotateBasedPositionCommand(parameters);
            }
            else if (commandText.StartsWith("reverse")) /*reverse positions x through y*/
            {
                var parameters = new object[]
                {
                  int.Parse(commandParts[2]),
                  int.Parse(commandParts[4])
                };

                command = new ReversePositionCommand(parameters);

            }
            else /* move position x to position y */
            {
                var parameters = new object[]
                {
                     int.Parse(commandParts[2]),
                     int.Parse(commandParts[5])
                };

                command = new MovePositionCommand(parameters);
            }

            return command;
        }
    }
}
