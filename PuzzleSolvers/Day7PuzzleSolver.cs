using AOC2016.Logic.Builders;
using AOC2016.Logic.Models;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.PuzzleSolvers
{
    public class Day7PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int numOfIPsThatSupportTLS = 0;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day7.txt");

            var builder = new IPv7Builder();

            foreach (string input in inputLines)
            {
                IPv7 ipAddress = builder.Build(input);

                if (IsSupportsTLS(ipAddress))
                {
                    numOfIPsThatSupportTLS++;
                }
            }

            return numOfIPsThatSupportTLS.ToString();
        }

        private bool IsSupportsTLS(IPv7 ipAddress)
        {
            return ipAddress.AddressParts.Any(addressPart => IsABBA(addressPart))
                    && ipAddress.HyperNets.All(hyperNet => !IsABBA(hyperNet));

        }

        private bool IsABBA(string input)
        {
            string ABBAPattern = @"(?<a>\w)(\w)\1\k<a>";

            MatchCollection matches =  Regex.Matches(input, ABBAPattern);
            return matches.Any(match => match.Groups[1].Value != match.Groups[2].Value);
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
