﻿using AOC;
using AOC2016.PuzzleSolvers;
using System;

namespace AOC2016
{
    class Program
    {
        static void Main(string[] args)
        {
            IPuzzleSolver solver = new Day25PuzzleSolver();

            var solution = solver.SolvePuzzlePart1();
            Console.WriteLine($"The solution to the puzzle is: {solution}");

            Console.ReadKey();
        }
    }
}
