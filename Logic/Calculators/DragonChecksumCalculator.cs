using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Calculators
{
    public class DragonChecksumCalculator
    {
        public string CalculateChecksum(string initialState, int diskSize)
        {
            string diskData = initialState;

            while(diskData.Length < diskSize) //We need to create more data
            {
                diskData = ExpandData(diskData);
            }

            diskData = diskData.Substring(0, diskSize); //Take only the required data

            string checksum = diskData; 

            while (checksum.Length % 2 == 0)
            {
                checksum = GetChecksum(checksum);
            }
          
            return checksum;
        }

        private string GetChecksum(string checksum)
        {
            var sbChecksum = new StringBuilder();

            for (int i = 0; i < checksum.Length; i = i + 2)
            {
                if (checksum[i] == checksum[i+1])
                {
                    sbChecksum.Append('1');
                } else
                {
                    sbChecksum.Append('0');
                }
            }

            return sbChecksum.ToString();
          
        }

        private string ExpandData(string diskData)
        {
            var sbReverseData = new StringBuilder();

            for (int i = diskData.Length - 1; i >= 0; i--)
            {
                sbReverseData.Append(diskData[i] == '0' ? '1' : '0');
            }

            return $"{diskData}0{sbReverseData}";
            
        }
    }
}
