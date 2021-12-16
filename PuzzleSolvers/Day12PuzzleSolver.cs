using AOC;
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
            string[] programLines = InputFilesHelper.GetInputFileLines("day12.txt");

            var initialRegisters = new Dictionary<string, int>
                        {
                            {"a", 0 },
                            {"b", 0 },
                            {"c", 1 },
                            {"d", 0 }
                        };


            var computer = new EasterBunnyComputer(initialRegisters);
            computer.LoadProgram(programLines);

            computer.ExecuteProgram();

            int registerValue = computer.GetRegisterValue("a");

            return registerValue.ToString();
        }
    }
}
