﻿using AOC2016.PuzzleSolvers;
using System;

namespace AOC2016
{
    class Program
    {
        static void Main(string[] args)
        {
            IPuzzleSolver solver = new Day21PuzzleSolver();

            var solution = solver.SolvePuzzlePart2();
            Console.WriteLine($"The solution to the puzzle is: {solution}");

            Console.ReadKey();
        }
    }
}
