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

            bool pathFound = false;

            while (!pathFound)
            {
                CubicalMazePathFinderResult result = pathFinder.FindPath(1, 1, 31, 39);
                pathFound = result.Success;

                maze.Show(result.Path);

                Thread.Sleep(200);

                if (pathFound)
                {
                    Console.WriteLine("Found Path!");
                    Console.ReadKey();

                    return result.Path.Points.Count.ToString();
                }
            }
            return string.Empty;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
