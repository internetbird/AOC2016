using AOC;
using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day24PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day24.test.txt");
            var map = new Map(inputLines);

            Point point0 = map.GetPointOfInterest(0);   
            Point point1 = map.GetPointOfInterest(4);

            int shortestDistance = map.FindShortestDistanceBetween(point0, point1);
            return shortestDistance.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
