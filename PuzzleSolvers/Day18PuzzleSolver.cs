using AOC2016.Logic.Calculators;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day18PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int numOfSafeTiles = CalculateNumOfSafeTiles(40);
          
            return numOfSafeTiles.ToString();
        }

        public string SolvePuzzlePart2()
        {
            int numOfSafeTiles = CalculateNumOfSafeTiles(400000);

            return numOfSafeTiles.ToString();
        }


        private int CalculateNumOfSafeTiles(int numOfRows)
        {
            var calculator = new TilesCalculator();

            bool[] tileRow = calculator.ParseTileRow("^..^^.^^^..^^.^...^^^^^....^.^..^^^.^.^.^^...^.^.^.^.^^.....^.^^.^.^.^.^.^.^^..^^^^^...^.....^....^.");

            int numOfSafeTiles = calculator.GetNumOfSafeTiles(tileRow);

            int rowCounter = 1;

            while (rowCounter < numOfRows)
            {
                tileRow = calculator.CalculateNextTileRow(tileRow);
                numOfSafeTiles += calculator.GetNumOfSafeTiles(tileRow);
                rowCounter++;
            }

            return numOfSafeTiles;
        }
    }
}
