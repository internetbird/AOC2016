using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.Logic
{
    public class EasterBunnyDecompressor
    {
        public string DecompressText(string compressedText)
        {
            var decompressedTextSb = new StringBuilder();
            MatchCollection metadataMatches = Regex.Matches(compressedText, @"\((?<metadata>\d+x\d+)\)");

            if (metadataMatches.Count == 0)
            {
                return compressedText;
            }

            if (metadataMatches[0].Index > 0) //Add the initial uncompressed string
            {
                decompressedTextSb.Append(compressedText.Substring(0, metadataMatches[0].Index));
            }

            for (int i = 0; i < metadataMatches.Count; i++)
            {
                Match currMatch = metadataMatches[i];
                Match nextMatch = i < metadataMatches.Count - 1 ? metadataMatches[i + 1] : null;

                if (nextMatch != null && currMatch.Index + currMatch.Length == nextMatch.Index) //An empty string section
                {
                    continue;
                }

                string[] metadataParts = currMatch.Groups["metadata"].Value.Split('x');
                int numOfChars = int.Parse(metadataParts[0]);
                int numOfRepeats = int.Parse(metadataParts[1]);

                string stringToRepeat = compressedText.Substring(currMatch.Index + currMatch.Length, numOfChars);
                string decompressedPart = stringToRepeat.Repeat(numOfRepeats);

                decompressedTextSb.Append(decompressedPart);

                //If required add the residual non-compressed string
                int nextSectionIndex = currMatch.Index + currMatch.Length + numOfChars;

                int nextMatchIndex = nextMatch != null ? nextMatch.Index : compressedText.Length - 1;

                if (nextSectionIndex < nextMatchIndex)
                {
                    string nonCompressedResidual = compressedText.Substring(nextSectionIndex, nextMatchIndex - nextSectionIndex);
                    decompressedTextSb.Append(nonCompressedResidual);
                }
            }
            return decompressedTextSb.ToString();
        }
    }
}
