using AOC;
using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.Logic.Builders
{
    public class StorageNodeBuilder
    {
        public List<StorageNode> Build(string inputFileName)
        {
            var storageNodes = new List<StorageNode>();

            string[] fileLines = InputFilesHelper.GetInputFileLines(inputFileName);

            for(int i = 2; i < fileLines.Length; i++)
            {
                var line = fileLines[i];
                StorageNode node = ParseLine(line);

                storageNodes.Add(node);

            }

            return storageNodes;
        }

        private StorageNode ParseLine(string line)
        {
            string[] lineParts = Regex.Split(line, @"\s+");

            int x = int.Parse(Regex.Match(lineParts[0], @"-x(\d+)").Groups[1].Value);
            int y = int.Parse(Regex.Match(lineParts[0], @"-y(\d+)").Groups[1].Value);
            var position = new Point(x, y);

            int size = int.Parse(Regex.Match(lineParts[1], @"(\d+)T").Groups[1].Value);
            int used = int.Parse(Regex.Match(lineParts[2], @"(\d+)T").Groups[1].Value);

            return new StorageNode(position, size, used);
        }
    }
}
