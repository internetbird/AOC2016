using AOC;
using AOC2016.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day23PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day23.txt");

            var initialRegisters = new Dictionary<string, int>
                        {
                            {"a", 7 },
                            {"b", 0 },
                            {"c", 0 },
                            {"d", 0 }
                        };

            var computer = new EasterBunnyComputer(initialRegisters);
            
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
