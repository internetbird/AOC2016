using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Utility
{
    public static class StringExtensions
    {
        public static string Repeat(this string s, int n)
            => new StringBuilder(s.Length * n).Insert(0, s, n).ToString();

        public static string SwapIndexes(this string input, int index1, int index2)
        {
            char[] charArray = input.ToCharArray();

            char index1Char = charArray[index1];
            char index2Char = charArray[index2];

            charArray[index1] = index2Char;
            charArray[index2] = index1Char;

            return new string(charArray);
        }

        public static string ShiftRight(this string input, int numOfPositions)
        {

            int shiftAmount =  numOfPositions % input.Length;

            string firstPart = input.Substring(input.Length - shiftAmount);
            string secondPart = input.Substring(0, input.Length - shiftAmount);
            return firstPart + secondPart;
        }

        public static string ShiftLeft(this string input, int numOfPositions)
        {
            int shiftAmount = numOfPositions % input.Length;

            string firstPart =  input.Substring(shiftAmount, input.Length - shiftAmount);
           string secondPart = input.Substring(0, shiftAmount);
           return firstPart + secondPart;
        }
    }
}
