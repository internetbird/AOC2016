using AOC;
using AOC2016.Logic.Models;

using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day20PuzzleSolver : IPuzzleSolver
    {
        List<IntRange> _intRanges;

        public string SolvePuzzlePart1()
        {
            LoadInput();

            uint minAllowedIp = 0;
            while (!IsAllowedIP(minAllowedIp))
            {
                minAllowedIp++;
            }

            return minAllowedIp.ToString();
        }

        private void LoadInput()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day20.txt");

            _intRanges = ParseInput(inputLines);
        }

        private bool IsAllowedIP(uint minAllowedIp)
        {
            foreach (IntRange range in _intRanges)
            {
                if (range.Contains(minAllowedIp))
                {
                    return false;
                }
            }

            return true;
        }

        private List<IntRange> ParseInput(string[] inputLines)
        {
            var intRanges = new List<IntRange>();

            foreach (string line in inputLines)
            {
                string[] rangeParts = line.Split("-");

                uint lowValue = uint.Parse(rangeParts[0]);
                uint highValue = uint.Parse(rangeParts[1]);

                intRanges.Add(new IntRange(lowValue, highValue));
            }
            return intRanges;
        }

        public string SolvePuzzlePart2()
        {
            LoadInput();
            int numOfAllowedIPs = 0;

            for (uint i = 14975795 /*Min valued allowed IP */; i <= uint.MaxValue; i++)
            {
                if (IsAllowedIP(i))
                {
                    numOfAllowedIPs++;
                }

                if (i % 100000 == 0)
                {
                    Console.WriteLine($"--{i}-- : Num of allowed IPs:{numOfAllowedIPs}");
                }
            }

            return numOfAllowedIPs.ToString();
        }
    }
}
