using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class IPv7
    {
        public IPv7()
        {
            AddressParts = new List<string>();
            HyperNets = new List<string>();
        }

        public List<string> AddressParts { get; set; }
        public List<string> HyperNets { get; set; }
    }
}
