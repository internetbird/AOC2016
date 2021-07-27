using AOC2016.Logic;
using AOC2016.Logic.Models;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day2PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day2.txt");

            var keypad = new Keypad();

            var bathroomCode = string.Empty;
            foreach (string line in inputLines)
            {
                ExecuteLineInstructions(line, keypad);
                bathroomCode += keypad.GetCurrentKey();
            }

            return bathroomCode;
        }

        private void ExecuteLineInstructions(string line, Keypad keypad)
        {
            for (int i = 0; i < line.Length; i++)
            {
                char currentInstructionChar = line[i];

                switch(currentInstructionChar)
                {
                    case 'U':
                        keypad.Move(KeypadDirection.Up);
                        break;
                    case 'D':
                        keypad.Move(KeypadDirection.Down);
                        break;
                    case 'R':
                        keypad.Move(KeypadDirection.Right);
                        break;
                    case 'L':
                        keypad.Move(KeypadDirection.Left);
                        break;
                }
            }
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
