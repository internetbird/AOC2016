using AOC;
using AOC2016.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day25PuzzleSolver : IPuzzleSolver
    {
        private const int MaxOutputLength = 10000;

        public string SolvePuzzlePart1()
        {
            string[] programLines = InputFilesHelper.GetInputFileLines("day25.txt");

            int registerValue = 1;
            bool clockSignalSuccess = false;


            while (!clockSignalSuccess && registerValue < 4000)
            {
                var initialRegisters = new Dictionary<string, int>
                        {
                            {"a", registerValue },
                            {"b", 0 },
                            {"c", 0 },
                            {"d", 0 }
                        };

                var computer = new EasterBunnyComputer(initialRegisters);
                computer.LoadProgram(programLines);

                string output = computer.ExecuteProgram(MaxOutputLength);

             
                if (output.Contains("01"))
                {
                    clockSignalSuccess = true;
                } else
                {
                    registerValue++;
                }
            }

            return registerValue.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
