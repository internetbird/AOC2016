using AOC;
using AOC2016.Logic;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.PuzzleSolvers
{
    public class Day9PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {
            var compressedText = InputFilesHelper.GetInputFileText("day9.txt");

            //Clear compressedText
            compressedText =  Regex.Replace(compressedText, @"\s", string.Empty);

            var decompressor = new EasterBunnyDecompressor();
            var decompressedText = decompressor.DecompressText(compressedText);

            //Remove spaces
            decompressedText = decompressedText.Replace(" ", string.Empty);

            return decompressedText.Length.ToString();
        }

        public string SolvePuzzlePart2()
        {
            var compressedText = InputFilesHelper.GetInputFileText("day9.txt");

            //Clear compressedText
            compressedText = Regex.Replace(compressedText, @"\s", string.Empty);

            var decompressor = new EasterBunnyDecompressor();
            long decompressedTextLength = decompressor.DecompressTextV2(compressedText);

        
            return decompressedTextLength.ToString();
        }
    }
}
