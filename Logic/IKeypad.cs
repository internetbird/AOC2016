using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic
{
    public interface IKeypad
    {
        void Move(KeypadDirection direction);
    }
}
