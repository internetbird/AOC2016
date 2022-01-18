using System;
using System.Collections.Generic;
using System.Drawing;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class StorageNode
    {
        public Point Position { get; set; }
        public int Size { get; set; }
        public int Used { get; set; }

        public StorageNode(Point position, int size, int used)
        {
            Position = position;
            Size = size;
            Used = used;

        }
    }
}
