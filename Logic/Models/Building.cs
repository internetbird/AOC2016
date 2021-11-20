using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Models
{
    internal class Building
    {
        public Building()
        {
            Floors = new List<Floor>();
        }
        public int CurrentFloor { get; set; }
        public int Steps { get; set; }
        public IList<Floor> Floors { get; }

        public Building Clone()
        {
            var clone = new Building()
            {
                Steps = Steps,
                CurrentFloor = CurrentFloor
            };
            foreach (var f in Floors)
                clone.Floors.Add(f.Clone());
            return clone;
        }

        public bool IsSolution()
        {
            return Floors.Last().IsComplete() && Floors.Take(Floors.Count - 1).All(f => f.IsEmpty());
        }

        public string GetState()
        {
            var result = new StringBuilder();
            result.Append($"{CurrentFloor}");
            for (int i = 0; i < Floors.Count; i++)
            {
                result.Append($"{i}{Floors[i].GetState()}");
            }
            return result.ToString();
        }
    }
}
