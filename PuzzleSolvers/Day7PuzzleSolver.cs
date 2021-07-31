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

        private bool IsSupportsSSL(IPv7 ipAddress)
        {
            List<Match> addressPartMatches = GetAllABAMatches(ipAddress.AddressParts);
            List<Match> hyperNetMatches = GetAllABAMatches(ipAddress.HyperNets);

            foreach (Match addressPartMatch in addressPartMatches)
            {
                 if (hyperNetMatches.Any(hyperNetMatch => hyperNetMatch.Groups[1].Value == addressPartMatch.Groups[2].Value
                        && hyperNetMatch.Groups[2].Value == addressPartMatch.Groups[1].Value))
                {
                    return true;
                }
            }
            return false;
        }

        private List<Match> GetAllABAMatches(List<string> inputs)
        {
            string ABAPattern = @"(?<a>\w)(\w)\k<a>";

            var allMatches = new List<Match>();

            foreach (string input in inputs)
            {
                for (int i = 0; i < input.Length - 2; i++)
                {
                    string subInputString = input.Substring(i);

                    MatchCollection partMatches = Regex.Matches(subInputString, ABAPattern);

                    foreach (Match partMatch in partMatches)
                    {
                        if (partMatch.Groups[1].Value != partMatch.Groups[2].Value)
                        {
                            allMatches.Add(partMatch);
                        }
                    }
                }
            }

            return allMatches;
        }

        private bool IsABBA(string input)
        {
            string ABBAPattern = @"(?<a>\w)(\w)\1\k<a>";

            MatchCollection matches =  Regex.Matches(input, ABBAPattern);
            return matches.Any(match => match.Groups[1].Value != match.Groups[2].Value);
        }

        public string SolvePuzzlePart2()
        {
             int numOfIPsThatSupportSSL = 0;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day7.txt");

            var builder = new IPv7Builder();

            foreach (string input in inputLines)
            {
                IPv7 ipAddress = builder.Build(input);

                if (IsSupportsSSL(ipAddress))
                {
                    numOfIPsThatSupportSSL++;
                }
            }

            return numOfIPsThatSupportSSL.ToString();
        }
    }
}
