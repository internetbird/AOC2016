using AOC;
using AOC2016.Utility;
using BirdLib;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.PuzzleSolvers
{
    public class Day14PuzzleSolver : IPuzzleSolver
    {

        private const string INPUT_SALT = "cuanljph";
        private const string SAME_LETTER_3_TIMES_REGEX = @"(\w)\1\1";
        private const int NthKeyForAnswer = 64;


        public string SolvePuzzlePart1()
        {
            int numOfHashes = 100000;
            int keyIndex = 0;

            List<string> hashes = CalculateHashes(numOfHashes);

            for (int i = 0; i < numOfHashes; i++)
            {
                 Match match  = Regex.Match(hashes[i], SAME_LETTER_3_TIMES_REGEX);
                if (match.Success)
                {
                    string charToRepeat = match.Groups[1].Value;
                    if (IsSameLetter5Times(charToRepeat, i+1,  i+1000, hashes))
                    {
                        keyIndex++;
                        if (keyIndex == NthKeyForAnswer)
                        {
                            return i.ToString();
                        }
                    }
                }
            }
            return string.Empty;
        }


        public string SolvePuzzlePart2()
        {
            int numOfHashes = 30000;
            int keyIndex = 0;

            List<string> hashes = CalculateHashes2016(numOfHashes);

            for (int i = 0; i < numOfHashes; i++)
            {
                Match match = Regex.Match(hashes[i], SAME_LETTER_3_TIMES_REGEX);
                if (match.Success)
                {
                    string charToRepeat = match.Groups[1].Value;
                    if (IsSameLetter5Times(charToRepeat, i + 1, i + 1000, hashes))
                    {
                        keyIndex++;
                        if (keyIndex == NthKeyForAnswer)
                        {
                            return i.ToString();
                        }
                    }
                }
            }


            return string.Empty;
        }

        private List<string> CalculateHashes2016(int maxIndex)
        {
            var hashes = new List<string>();
            for (int i = 0; i < maxIndex; i++)
            {
                Console.WriteLine($"Calculated {i*100/maxIndex}%");

                var hash = CryptographyHelper.CreateMD5Hash(INPUT_SALT + i).ToLower();
                for (int j = 0; j < 2016; j++)
                {
                    hash = CryptographyHelper.CreateMD5Hash(hash).ToLower();
                }
                hashes.Add(hash);
            }

            return hashes;
        }

        private List<string> CalculateHashes(int maxIndex)
        {
            var hashes = new List<string>();

            for (int i = 0; i < maxIndex; i++)
            {
                var hash = CryptographyHelper.CreateMD5Hash(INPUT_SALT + i);
                hashes.Add(hash);
            }

            return hashes;
            
        }

        private bool IsSameLetter5Times(string charToRepeat, int startIndex, int endIndex, List<string> hashes)
        {
            for (int i = startIndex; i <= endIndex; i++)
            {
                if (hashes[i].Contains(charToRepeat.Repeat(5)))
                {
                    return true;
                }
            };

            return false;
        }
    }
}
