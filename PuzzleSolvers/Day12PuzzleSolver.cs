using AOC2016.Logic;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day12PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day12.txt");

            var computer = new EasterBunnyComputer();
            computer.LoadProgram(programLines);

            computer.ExecuteProgram();

            int registerValue = computer.GetRegisterValue("a");

            return registerValue.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
