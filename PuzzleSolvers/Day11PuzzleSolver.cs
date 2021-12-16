using AOC;
using AOC2016.Logic.Models;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.RegularExpressions;

namespace AOC2016.PuzzleSolvers
{
    public class Day11PuzzleSolver : IPuzzleSolver
    {
        private readonly Queue<Building> _unvisited = new Queue<Building>();
        private readonly HashSet<string> _visited = new HashSet<string>();

        public string SolvePuzzlePart1()
        {
           string[] inputLines = InputFilesHelper.GetInputFileLines("day11.txt");

            return Search(inputLines).ToString();

        }

        public string SolvePuzzlePart2()
        {
            string[] inputLines = InputFilesHelper.GetInputFileLines("day11.txt");

            inputLines[0] =
                 "The first newFloorNr contains a promethium generator, a elerium generator, a elerium-compatible microchip, a dilithium generator, a dilithium-compatible microchip " +
                 "and a promethium-compatible microchip.";


            return Search(inputLines).ToString();

        }

        private int Search(string[] input)
        {
            var startBuilding = ParseInput(input);
            _unvisited.Enqueue(startBuilding);

            int minimumSteps = int.MaxValue;
            while (_unvisited.Count > 0)
            {
                Building current = _unvisited.Dequeue();

                if (_visited.Contains(current.GetState()))
                    continue;
                _visited.Add(current.GetState());

                if (current.IsSolution())
                {
                    if (current.Steps < minimumSteps)
                    {
                        minimumSteps = current.Steps;
                        break;
                    }
                }

                ICollection<Building> nextMoves = GenerateNextStates(current);
                foreach (var building in nextMoves)
                    _unvisited.Enqueue(building);
            }
            return minimumSteps;
        }

        private ICollection<Building> GenerateNextStates(Building current)
        {
            var result = new List<Building>();
            var currentFloor = current.Floors[current.CurrentFloor];

            var compatibleItems = new List<Tuple<string, string>>();
            List<string> allItems = currentFloor.Generators.Concat(currentFloor.Microchips).ToList();
            compatibleItems.AddRange(
                allItems.SelectMany(x => allItems, Tuple.Create)
                    .Where(t => t.Item1 != t.Item2).Where(x => ItemsCompatible(x.Item1, x.Item2)));
            compatibleItems.AddRange(allItems.Select(x => Tuple.Create<string, string>(x, null)));

            foreach (Tuple<string, string> t in compatibleItems)
            {
                ICollection<string> items = new List<string>() { t.Item1, t.Item2 };
                if (current.CurrentFloor > 0)
                {
                    // down
                    Building newState = current.Clone();
                    newState = GenerateState(newState, items, current.CurrentFloor - 1);
                    if (newState != null && !_visited.Contains(newState.GetState()))
                        result.Add(newState);
                }

                if (current.CurrentFloor < 3)
                {
                    // up
                    Building newState = current.Clone();
                    newState = GenerateState(newState, items, current.CurrentFloor + 1);
                    if (newState != null && !_visited.Contains(newState.GetState()))
                        result.Add(newState);
                }
            }
            return result;
        }

        private static Building GenerateState(Building newState, ICollection<string> items, int newFloorNr)
        {
            newState.Steps += 1;
            Floor currentFloor = newState.Floors[newState.CurrentFloor];
            currentFloor.RemoveItems(items);

            Floor newFloor = newState.Floors[newFloorNr];
            newFloor.AddItems(items);

            newState.CurrentFloor = newFloorNr;

            if (currentFloor.IsValid() && newFloor.IsValid())
                return newState;
            return null;
        }

        private static bool ItemsCompatible(string item1, string item2)
        {
            var item1Elements = item1.Split(' ');
            var item2Elements = item2.Split(' ');

            return Equals(item1Elements.Last(), item2Elements.Last()) ||
                   Equals(item1Elements.First(), item2Elements.First());
        }


        private static Building ParseInput(IEnumerable<string> input)
        {
            Building resultBuilding = new Building();
            foreach (var line in input)
            {
                var elements = Regex.Split(line, " a ");
                var microchips = elements.Where(e => e.Contains("microchip")).Select(e => e.Replace("and", "").Replace(",", "").Replace(".", "").Replace("-compatible", "").Trim()).ToList();
                var generators = elements.Where(e => e.Contains("generator")).Select(e => e.Replace("and", "").Replace(",", "").Replace(".", "").Trim()).ToList();
                var floor = new Floor
                {
                    Generators = generators,
                    Microchips = microchips
                };
                resultBuilding.Floors.Add(floor);
            }
            resultBuilding.CurrentFloor = 0;
            resultBuilding.Steps = 0;
            return resultBuilding;
        }
    }
}
