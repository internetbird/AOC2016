﻿using AOC;
using AOC2016.Logic.Builders;
using AOC2016.Logic.Models;

using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day4PuzzleSolver : IPuzzleSolver
    {
        public string SolvePuzzlePart1()
        {

            int sumOfRealRoomsSectorIds = 0;

            string[] inputLines = InputFilesHelper.GetInputFileLines("day4.txt");
            var builder = new RoomDataBuilder();

            List<RoomData> roomData = builder.Build(inputLines);

            foreach (RoomData data in roomData)
            {
                if (IsRealRoomData(data))
                {
                    sumOfRealRoomsSectorIds += data.SectorId;
                }
            }

            return sumOfRealRoomsSectorIds.ToString();
        }
       

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day4.txt");
            var builder = new RoomDataBuilder();

            List<RoomData> roomData = builder.Build(inputLines);

            foreach (RoomData data in roomData)
            {
                if (IsNorthPoleRoomData(data))
                {
                    return data.SectorId.ToString();
                }
            }


            return string.Empty;
        }

        private bool IsNorthPoleRoomData(RoomData data)
        {

            var decipheredName = string.Empty;

            for (int i = 0; i < data.EncryptedName.Length; i++)
            {
                decipheredName += DecipherChar(data.EncryptedName[i], data.SectorId);
            }

            Console.WriteLine(decipheredName);

            if (decipheredName.Contains("north"))
            {
                return true;
            }

            return false;
            
        }

        private string DecipherChar(char charToDecypher, int shiftCipher)
        {

            if (charToDecypher == '-')
            {
                return " ";
            }

            int charOffset = (charToDecypher - 'a' + shiftCipher) % ('z' - 'a' + 1);
            char decipheredChar = (char)('a' + charOffset);

            return decipheredChar.ToString();
        }

        private bool IsRealRoomData(RoomData data)
        {
            Dictionary<char, int> letterDictionary = BuildLetterCountDictionary(data.EncryptedName);

            char[] top5Letters = letterDictionary.OrderByDescending(keyVal => keyVal.Value)
                                 .ThenBy(keyVal => keyVal.Key).Take(5)
                                 .Select(keyVal => keyVal.Key).ToArray();

            string calculatedChecksum = new string(top5Letters);

            return data.Checksum == calculatedChecksum;
        }

        private Dictionary<char, int> BuildLetterCountDictionary(string encryptedName)
        {
            var dict = new Dictionary<char, int>();
            string cleanName = encryptedName.Replace("-", string.Empty);

            for (int i = 0; i < cleanName.Length; i++)
            {
                char currChar = cleanName[i];

                if (!dict.ContainsKey(currChar))
                {
                    dict.Add(currChar, 1);
                } else
                {
                    dict[currChar]++;
                }
            }

            return dict;
        }
    }
}
