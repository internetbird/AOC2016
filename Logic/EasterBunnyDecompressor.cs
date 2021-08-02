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


        public string DecompressTextV2(string compressedText)
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

            //Check if there are any metadata sections left after the last decompression
            metadataMatches = Regex.Matches(decompressedTextSb.ToString(), @"\((?<metadata>\d+x\d+)\)");

            if (metadataMatches.Count == 0)
            {
                return decompressedTextSb.ToString();
            } else //metadata exists, perform decompression again
            {
                return DecompressTextV2(decompressedTextSb.ToString());
            }
        }
    }
}
