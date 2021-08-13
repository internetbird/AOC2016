using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class MazePoint
    {

        public MazePoint(int x, int y)
        {
            X = x;
            Y = y;
        }

        public int X { get; private set; }
        public int Y { get; private set; }
    }
}
