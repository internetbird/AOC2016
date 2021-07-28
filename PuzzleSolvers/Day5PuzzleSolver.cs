using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day5PuzzleSolver : IPuzzleSolver
    {

        private const string PuzzleInput = "wtnhxymk";

        public string SolvePuzzlePart1()
        {
            var password = string.Empty;
            int postfixIndex = 0;

            while(password.Length < 8)
            {
                string md5Hash = CryptographyHelper.CreateMD5Hash(PuzzleInput + postfixIndex);
                if (md5Hash.StartsWith("00000"))
                {
                    password += md5Hash[5];
                    Console.WriteLine(new string('*', password.Length) + " " + password);
                }
                postfixIndex++;
            }

            return password;
        }

        public string SolvePuzzlePart2()
        {
            throw new NotImplementedException();
        }
    }
}
