using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Calculators
{
    public class StorageNodeCalculator
    {
        public int GetNumOfViableNodePairs(List<StorageNode> nodes)
        {
            int numOfViableNodePairs = 0;

            for (int i = 0; i < nodes.Count; i++)
            {
                StorageNode node1 = nodes[i];
                if (node1.Used == 0) continue;
               
                for (int j = 0; j < nodes.Count; j++)
                {
                    if (i == j) continue;
                    StorageNode node2 = nodes[j];
                    if (node1.Used <= (node2.Size - node2.Used))
                    {
                        numOfViableNodePairs++;
                    }
                }
            }
            return numOfViableNodePairs;
        }
    }
}
