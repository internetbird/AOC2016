using AOC2016.Logic.Builders;
using AOC2016.Logic.Calculators;
using AOC2016.Logic.Models;
using AOC2016.Logic.Models.ScrambleCommands;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day21PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day21.txt");

            var scrambleCommands = new List<IScrambleCommand>();

            var commandBuilder = new ScrambleCommandBuilder();
            foreach (string line in inputLines)
            {
                IScrambleCommand command = commandBuilder.BuildCommand(line);
                scrambleCommands.Add(command);
            }

            string hash = "abcdefgh";
            foreach (IScrambleCommand command in scrambleCommands)
            {
                hash = command.Execute(hash);
            }
            return hash;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
