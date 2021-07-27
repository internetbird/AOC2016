using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic
{
    public class Keypad : IKeypad
    {
        private int[,] Keys;
        private int _currRowIndex;
        private int _currColumnIndex;

        private const int MaxIndex = 2;

        public Keypad()
        {
            Keys = new int[,]
            {
               {1,2,3},
               {4,5,6},
               {7,8,9}
            };

            _currRowIndex = 1;
            _currColumnIndex = 1;
        }

        public void Move(KeypadDirection direction)
        {
            switch(direction)
            {
                case KeypadDirection.Up:
                    if (_currRowIndex > 0)
                    {
                        _currRowIndex--;
                    }
                    break;
                case KeypadDirection.Down:
                    if (_currRowIndex < MaxIndex)
                    {
                        _currRowIndex++;
                    }
                    break;
                case KeypadDirection.Right:
                    if (_currColumnIndex < MaxIndex)
                    {
                        _currColumnIndex++;
                    }
                    break;
                case KeypadDirection.Left:
                    if (_currColumnIndex > 0)
                    {
                        _currColumnIndex--;
                    }
                    break;
            }
        }

        public string GetCurrentKey()
        {
            return Keys[_currRowIndex, _currColumnIndex].ToString();
        }
    }
}
