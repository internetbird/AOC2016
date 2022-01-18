using AOC;
using AOC2016.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day25PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day25.txt");

            var computer = new EasterBunnyComputer();
            computer.LoadProgram(programLines);


            return string.Empty;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
