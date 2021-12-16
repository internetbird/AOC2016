using AOC;
using AOC2016.Logic.Calculators;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day6PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day6.txt");

            var message = string.Empty;

            var calculator = new LetterFrequencyCalculator();

            for (int i = 0; i < inputLines[0].Length ; i++)
            {
                message += calculator.GetMostFrequestCharAtPoisition(inputLines, i);
            }

            return message;
        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day6.txt");

            var message = string.Empty;

            var calculator = new LetterFrequencyCalculator();

            for (int i = 0; i < inputLines[0].Length; i++)
            {
                message += calculator.GetLeastFrequestCharAtPoisition(inputLines, i);
            }

            return message;
        }
    }
}
