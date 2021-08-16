using AOC2016.Logic.Calculators;
using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AOC2016.PuzzleSolvers
{
    public class Day13PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var maze = new CubicalMaze(1350);
            var pathFinder = new CubicalMazePathFinder(maze);

            CubicalMazePathFinderResult result = pathFinder.FindAllPaths(1, 1, 31, 39);
          
            return (result.Paths[0].Points.Count -1).ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
