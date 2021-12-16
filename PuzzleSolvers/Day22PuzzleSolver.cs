using AOC;
using AOC2016.Logic.Builders;
using AOC2016.Logic.Calculators;
using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day22PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var builder = new StorageNodeBuilder();

            List<StorageNode> storageNodes = builder.Build("day22.txt");

            var calculator = new StorageNodeCalculator();
            int numOfViablePairs = calculator.GetNumOfViableNodePairs(storageNodes);

            return numOfViablePairs.ToString();
        }

        public string SolvePuzzlePart2()
        {
            var builder = new StorageNodeBuilder();

            List<StorageNode> storageNodes = builder.Build("day22.txt");


            return String.Empty;
        }
    }
}
