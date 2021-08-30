using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day17PuzzleSolver : IPuzzleSolver
    {
        private const string PassCode = "bwnlcvfs";

        public string SolvePuzzlePart1()
        {
            var navigator = new RoomsGridNavigator(PassCode);

            string shortestPath = navigator.FindShortestPathToVault();

            return shortestPath;
        }

        public string SolvePuzzlePart2()
        {
            var navigator = new RoomsGridNavigator(PassCode);

            int longestPathLength = navigator.FindLongestPathLengthToVault();

            return longestPathLength.ToString();
        }
    }
}
