using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class CubicalMazePath
    {
        public List<MazePoint> Points { get; set; }

        public CubicalMazePath()
        {
            Points = new List<MazePoint>();
        }
    }
}
