using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Calculators
{
    public class TilesCalculator
    {
        public bool[] CalculateNextTileRow(bool[] currTileRow)
        {
            var nextRow = new bool[currTileRow.Length];

            for (int i = 0; i < currTileRow.Length; i++)
            {
                bool leftTile =  i > 0 ? currTileRow[i-1] : false;
                bool centerTile = currTileRow[i];
                bool rightTile =  i < (currTileRow.Length - 1) ? currTileRow[i+1] : false;

                if ((leftTile && centerTile && !rightTile) ||
                    (centerTile && rightTile && !leftTile) ||
                    (leftTile && !centerTile && !rightTile) || 
                    (rightTile && !centerTile && !leftTile))
                {
                    nextRow[i] = true;
                } 
            }
            return nextRow;
        }

        public int GetNumOfSafeTiles(bool[] tileRow)
        {
            return tileRow.Sum(tile => tile ? 0 : 1);
        }

        public bool[] ParseTileRow(string tileRowText)
        {
            return tileRowText.Select(tile => tile == '^').ToArray();
        }

        public string GetTileRowString(bool[] tileRow)
        {
            return new string(tileRow.Select(tile => tile ? '^' : '.').ToArray());
        }
    }
}
