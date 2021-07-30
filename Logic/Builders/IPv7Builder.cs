using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.Logic.Builders
{
    public class IPv7Builder
    {
        public IPv7 Build(string ipString)
        {
            var result = new IPv7();

           int[] openingBracketIndexes = Regex.Matches(ipString, @"\[").Select(match => match.Index).ToArray();
           int[] closingBracketIndexes = Regex.Matches(ipString, @"\]").Select(match => match.Index).ToArray();


            int lastAddressPartIndex = 0;


            for (int i = 0; i < openingBracketIndexes.Length; i++)
            {
                string addressPart = ipString.Substring(lastAddressPartIndex,  openingBracketIndexes[i] - lastAddressPartIndex);

                string hyperNet = ipString.Substring(openingBracketIndexes[i] + 1,
                                            closingBracketIndexes[i] - openingBracketIndexes[i] - 1);

                result.AddressParts.Add(addressPart);
                result.HyperNets.Add(hyperNet);

                lastAddressPartIndex = closingBracketIndexes[i] + 1;
            }

            if (lastAddressPartIndex < ipString.Length)
            {
                string lastAddressPart = ipString.Substring(lastAddressPartIndex);
                result.AddressParts.Add(lastAddressPart);
            }

            return result;
        }
    }
}
