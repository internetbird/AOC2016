using AOC;
using AOC2016.Logic.Builders;
using AOC2016.Logic.Models;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day8PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var display = new PixelsDisplay();
            string[] inputLines = InputFilesHelper.GetInputFileLines("day8.txt");
            var commandBuilder = new PixelsDisplayCommandBuilder();

            foreach  (string inputLine in inputLines)
            {
                Console.WriteLine();
                Console.WriteLine($"Executing command: {inputLine}");

                PixelsDisplayCommand command =  commandBuilder.Build(inputLine);
                display.ExecuteCommand(command);
                display.Show();
            }

            return display.GetNumLitPixels().ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
