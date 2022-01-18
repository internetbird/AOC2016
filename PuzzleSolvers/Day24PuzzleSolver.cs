using AOC;
using AOC2016.Logic.Models;
using BirdLib;
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
            string[] inputLines = InputFilesHelper.GetInputFileLines("day24.txt");
            var map = new Map(inputLines);
            var permutationGenerator = new PermutationGenerator();

            var distancesDictionary = new Dictionary<Tuple<int, int>, int>();
            var couples = permutationGenerator.GetAllCouples(new List<int> { 0, 1, 2, 3, 4, 5, 6, 7 });

            foreach (Tuple<int, int> couple in couples)
            {
                var point1 = map.GetPointOfInterest(couple.Item1);
                var point2 = map.GetPointOfInterest(couple.Item2);

                int shortestDistance = map.FindShortestDistanceBetween(point1, point2);

                distancesDictionary.Add(couple, shortestDistance);
            }

            int minDistance = int.MaxValue;
            List<int[]> routes = permutationGenerator.GetAllPermutations(new[] { 1, 2, 3, 4, 5, 6, 7 });

            foreach (int[] route in routes)
            {
                int totalDistance = CalculateTotalDistance(route.PrependItem(0), distancesDictionary);
                if (totalDistance < minDistance)
                {
                    minDistance = totalDistance;
                }

            }

            return minDistance.ToString();
        }

        private int CalculateTotalDistance(int[] route, Dictionary<Tuple<int, int>, int> distancesDictionary)
        {
            var totalDistance = 0;
            
            for (int i = 0; i < route.Length - 1; i++)
            {
                totalDistance += GetDistanceBetweenPoints(route[i], route[i + 1], distancesDictionary);
            }

            return totalDistance;
        }

        private int GetDistanceBetweenPoints(int point1Index, int point2Index, Dictionary<Tuple<int, int>, int> distancesDictionary)
        {
            if (distancesDictionary.ContainsKey(Tuple.Create(point1Index, point2Index)))
            {
                return distancesDictionary[Tuple.Create(point1Index, point2Index)];
            } else
            {
                return distancesDictionary[Tuple.Create(point2Index, point1Index)];
            }
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
