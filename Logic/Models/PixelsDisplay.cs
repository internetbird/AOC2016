using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class PixelsDisplay
    {
        private bool[,] _pixels;

        private const int NumOfRows = 6;
        private const int NumOfColumns = 50;

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
            bool[,] newPixels = null;

            switch (command.Type)
            {
                case PixelsDisplayCommandType.Rectangle:
                    for (int i = 0; i < command.CommandValue2; i++)
                    {
                        for (int j = 0; j < command.CommandValue1; j++)
                        {
                            _pixels[i, j] = true;
                        }
                    }
                    break;
                case PixelsDisplayCommandType.RotateRow:

                    newPixels = _pixels.Clone() as bool[,];

                    int rowIndexToRotate = command.CommandValue1;
                    int rowRotateBy = command.CommandValue2;

                    for (int i = 0; i < NumOfColumns; i++)
                    {
                        int originalColumnIndex = i < rowRotateBy ?
                                        NumOfColumns - rowRotateBy + i : i - rowRotateBy;

                        newPixels[rowIndexToRotate, i] = _pixels[rowIndexToRotate, originalColumnIndex];
                    }
                    _pixels = newPixels;


                    break;
                case PixelsDisplayCommandType.RotateColumn:
                    newPixels = _pixels.Clone() as bool[,];

                    int columnIndexToRotate = command.CommandValue1;
                    int columnRotateBy = command.CommandValue2;

                    for (int  i = 0;  i < NumOfRows;  i++)
                    {
                        int originalRowIndex = i < columnRotateBy ?
                                        NumOfRows - columnRotateBy + i : i - columnRotateBy;

                        newPixels[i, columnIndexToRotate] = _pixels[originalRowIndex, columnIndexToRotate];
                    }

                    _pixels = newPixels;
                    break;
                default:
                    break;
            }


        }
    }
}
