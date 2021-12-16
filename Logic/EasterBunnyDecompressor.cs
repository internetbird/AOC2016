using AOC2016.Utility;
using BirdLib;
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

            int lastScannedIndex = 0;

            for (int i = 0; i < metadataMatches.Count; i++)
            {
                Match currMatch = metadataMatches[i];

                if (currMatch.Index < lastScannedIndex) //Don't include metadatas that were considered as regaulr text
                {
                    continue;
                }

                Match nextMatch = i < metadataMatches.Count - 1 ? metadataMatches[i + 1] : null;

                string[] metadataParts = currMatch.Groups["metadata"].Value.Split('x');
                int numOfChars = int.Parse(metadataParts[0]);
                int numOfRepeats = int.Parse(metadataParts[1]);

                string stringToRepeat = compressedText.Substring(currMatch.Index + currMatch.Length, numOfChars);
                string decompressedPart = stringToRepeat.Repeat(numOfRepeats);

                decompressedTextSb.Append(decompressedPart);

               
                lastScannedIndex = currMatch.Index + currMatch.Length + numOfChars;

                int nextMatchIndex = nextMatch != null ? nextMatch.Index : compressedText.Length;

                if (lastScannedIndex < nextMatchIndex)
                {
                    string nonCompressedResidual = compressedText.Substring(lastScannedIndex, nextMatchIndex - lastScannedIndex);
                    decompressedTextSb.Append(nonCompressedResidual);

                    lastScannedIndex += (nextMatchIndex - lastScannedIndex);
                }
            }

            //Add residual at the end in case it was not already added
            if (lastScannedIndex < compressedText.Length)
            {
                string nonCompressedResidual = compressedText.Substring(lastScannedIndex,
                                                    compressedText.Length - lastScannedIndex);
                decompressedTextSb.Append(nonCompressedResidual);
            }

            return decompressedTextSb.ToString();
        }


        public long DecompressTextV2(string input)
        {
            long length = 0;
            var toDecompressInput = input.Replace(" ", "");
            for (int i = 0; i < toDecompressInput.Length; i++)
            {
                if (toDecompressInput[i] == '(')
                {
                    int closingIndex = toDecompressInput.IndexOf(")", i, StringComparison.Ordinal);
                    string marker = toDecompressInput.Substring(i + 1, closingIndex - i - 1); // skipping ( + )
                    var markerElements = marker.Split('x');
                    int chars = int.Parse(markerElements[0]);
                    int repeats = int.Parse(markerElements[1]);

                    var markedInput = toDecompressInput.Substring(closingIndex + 1, chars);
                    length += DecompressTextV2(markedInput) * repeats;
                   
                    i = closingIndex + chars; // + 1 -> already added by incrementor;
                }
                else
                {
                    length++;
                }
            }
            return length;

        }
    }
}
