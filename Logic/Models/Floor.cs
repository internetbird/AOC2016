using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Models
{
    internal class Floor
    {
        public IList<string> Microchips { get; set; }
        public IList<string> Generators { get; set; }


        public Floor Clone()
        {
            var clone = new Floor
            {
                Generators = new List<string>(),
                Microchips = new List<string>()
            };
            foreach (var mc in Microchips)
                clone.Microchips.Add(mc);
            foreach (var g in Generators)
                clone.Generators.Add(g);
            return clone;
        }

        public bool IsValid()
        {
            return Microchips.All(mc => Generators.Contains(mc.Replace("microchip", "generator"))) || !Generators.Any();
        }

        public bool IsComplete()
        {
            return IsValid() && Microchips.Any() && Generators.Any();
        }

        public bool IsEmpty()
        {
            return !Microchips.Any() && !Generators.Any();
        }

        public void RemoveItems(ICollection<string> items)
        {
            foreach (var mc in items.Where(i => i != null && i.Contains("microchip")))
                Microchips.Remove(mc);
            foreach (var g in items.Where(i => i != null && i.Contains("generator")))
                Generators.Remove(g);
        }

        public void AddItems(ICollection<string> items)
        {
            foreach (var mc in items.Where(i => i != null && i.Contains("microchip")))
                Microchips.Add(mc);
            foreach (var g in items.Where(i => i != null && i.Contains("generator")))
                Generators.Add(g);
        }

        public string GetState()
        {
            var mc = Microchips.Count(m => !Generators.Any(g => g.Contains(m.Replace("microchip", "generator"))));
            var gen = Generators.Count(g => !Microchips.Any(m => m.Contains(g.Replace("microchip", "generator"))));
            var p = Generators.Count(g => Microchips.Any(m => m.Contains(g.Replace("generator", "microchip"))));

            return $"{mc}{gen}{p}";
        }
    }
}
