using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.Logic.Builders
{
    public class RoomDataBuilder
    {
        public List<RoomData> Build(string[] inputStrings)
        {
            var data = new List<RoomData>();

            for (int i = 0; i < inputStrings.Length; i++)
            {
                RoomData roomData = ParseInputString(inputStrings[i]);

                data.Add(roomData);
            }

            return data;
        }

        private RoomData ParseInputString(string input)
        {
            var roomData = new RoomData();

            int sectorId =  int.Parse(Regex.Match(input, @"\d+").Value);
            string checkSum = Regex.Match(input, @"\[(\w+)\]").Groups[1].Value;
            string encryptedName = input.Substring(0, input.LastIndexOf('-'));

            roomData.EncryptedName = encryptedName;
            roomData.SectorId = sectorId;
            roomData.Checksum = checkSum;

            return roomData;
        }
    }
}
