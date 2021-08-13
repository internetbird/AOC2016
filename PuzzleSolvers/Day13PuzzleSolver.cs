using AOC2016.Logic.Calculators;
using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day13PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var maze = new CubicalMaze(1350);
            maze.Show();

            var pathFinder = new CubicalMazePathFinder();
            int numOfSteps = pathFinder.FindMinNumOfStepsForPoints(maze, 1, 1, 31, 39);
            
            return numOfSteps.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
