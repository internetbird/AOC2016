using AOC;
using AOC2016.Logic.Calculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day16PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var checksumCalculator = new DragonChecksumCalculator();
            string checksum = checksumCalculator.CalculateChecksum("11101000110010100", 272);

            return checksum;
        }

        public string SolvePuzzlePart2()
        {
            var checksumCalculator = new DragonChecksumCalculator();
            string checksum = checksumCalculator.CalculateChecksum("11101000110010100", 35651584);

            return checksum;
        }
    }
}
