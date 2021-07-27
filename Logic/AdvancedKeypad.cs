using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic
{
    public class AdvancedKeypad : IKeypad
    {
        private string[,] Keys;

        private int _currRowIndex;
        private int _currColumnIndex;

        private const int MaxIndex = 4;

        public AdvancedKeypad()
        {
            Keys = new string[,]
              {
                   {null, null, "1" ,null,null},
                   {null, "2", "3", "4", null},
                   {"5", "6", "7", "8", "9" },
                   {null, "A", "B", "C", null },
                   {null, null, "D", null,  null}
              };

            _currRowIndex = 2;
            _currColumnIndex = 0;
        }

        public string GetCurrentKey()
        {
            return Keys[_currRowIndex, _currColumnIndex];
        }

        public void Move(KeypadDirection direction)
        {
            switch (direction)
            {
                case KeypadDirection.Up:
                    if (_currRowIndex > 0)
                    {
                        if (Keys[_currRowIndex - 1,_currColumnIndex] != null)
                        {
                            _currRowIndex--;
                        }
                    }
                    break;
                case KeypadDirection.Down:
                    if (_currRowIndex < MaxIndex)
                    {
                        if(Keys[_currRowIndex + 1, _currColumnIndex] != null)
                        {
                            _currRowIndex++;
                        }
                     
                    }
                    break;
                case KeypadDirection.Right:
                    if (_currColumnIndex < MaxIndex)
                    {
                        if (Keys[_currRowIndex, _currColumnIndex + 1] != null)
                        {
                            _currColumnIndex++;
                        }
                       
                    }
                    break;
                case KeypadDirection.Left:
                    if (_currColumnIndex > 0)
                    {
                        if (Keys[_currRowIndex, _currColumnIndex - 1] != null)
                        {
                            _currColumnIndex--;
                        }
                       
                    }
                    break;
            }
        }
    }
}
