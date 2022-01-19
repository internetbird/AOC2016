using AOC;

using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.PuzzleSolvers
{
    public class Day3PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            int numOfValidTriangles = 0;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day3.txt");
            foreach (string inputLine in inputLines)
            {
                MatchCollection matches = Regex.Matches(inputLine, @"\d+");

                int side1 = int.Parse(matches[0].Value);
                int side2 = int.Parse(matches[1].Value);
                int side3 = int.Parse(matches[2].Value);

                if (IsValidTriangle(side1, side2, side3))
                {
                    numOfValidTriangles++;
                }
            }
            return numOfValidTriangles.ToString();
        }

        private bool IsValidTriangle(int side1, int side2, int side3)
        {
            return ((side1 + side2 > side3) && (side2 + side3) > side1 && (side1 + side3) > side2);
        }

        public string SolvePuzzlePart2()
        {
            int numOfValidTriangles = 0;
            string[] inputLines = InputFilesHelper.GetInputFileLines("day3.txt");

            for (int i = 0; i < inputLines.Length; i+=3)
            {
                string line1 = inputLines[i];
                string line2 = inputLines[i + 1];
                string line3 = inputLines[i + 2];

                MatchCollection line1Matches = Regex.Matches(line1, @"\d+");
                MatchCollection line2Matches = Regex.Matches(line2, @"\d+");
                MatchCollection line3Matches = Regex.Matches(line3, @"\d+");

                //Check for each of the columns
                for (int j = 0; j <= 2; j++)
                {
                    int side1 = int.Parse(line1Matches[j].Value);
                    int side2 = int.Parse(line2Matches[j].Value);
                    int side3 = int.Parse(line3Matches[j].Value);

                    if (IsValidTriangle(side1, side2, side3))
                    {
                        numOfValidTriangles++;
                    }
                }

            }

            return numOfValidTriangles.ToString();
        }
    }
}
