using AOC2016.Logic;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day9PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var compressedText = InputFilesHelper.GetInputFileText("day9.txt");
            var decompressor = new EasterBunnyDecompressor();
            var decompressedText = decompressor.DecompressText(compressedText);
            return decompressedText.Length.ToString();
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
