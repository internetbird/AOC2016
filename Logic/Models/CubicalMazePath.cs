using System;
using System.Collections.Generic;
using System.Linq;
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

        public bool ContainsPoint(int x, int y)
        {
            return Points.Any(point => point.X == x && point.Y == y);
            
        }
    }
}
