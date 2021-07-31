using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class PixelsDisplay
    {
        private bool[,] _pixels;

        private const int NumOfRows = 50;
        private const int NumOfColumns = 6;

        public PixelsDisplay()
        {
            _pixels = new bool[NumOfRows, NumOfColumns];
        }

        public void Show()
        {
            for (int row = 0; row < NumOfRows; row++)
            {
                var sb = new StringBuilder();
                for (int column = 0; column < NumOfColumns; column++)
                {
                    sb.Append(_pixels[row,column] ? "#" : ".");
                }

                Console.WriteLine(sb.ToString());
            }
        }

        public int GetNumLitPixels()
        {

            int numOfLitPixels = 0;

            for (int i = 0; i < NumOfRows; i++)
            {
                for (int j = 0; j < NumOfColumns; j++)
                {
                    if (_pixels[i, j])
                    {
                        numOfLitPixels++;
                    }
                }
            }
            return numOfLitPixels;
        }

        public void ExecuteCommand(PixelsDisplayCommand command)
        {

        }
    }
}
