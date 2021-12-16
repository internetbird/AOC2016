using AOC;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.PuzzleSolvers
{
    public class Day19PuzzleSolver : IPuzzleSolver
    {

        private const int INPUT = 3018458;
        private int[] _elfs = null;

        public string SolvePuzzlePart1()
        {
            _elfs = Enumerable.Repeat(1, INPUT).ToArray();

            int winningElf = -1;
            int currTablePosition = 0;
           
            while(winningElf < 0)
            {
                var currElf = _elfs[currTablePosition];

                if (currElf == 0)
                {
                    currTablePosition = (currTablePosition + 1) % INPUT;
                    continue;
                }

                int tablePositionToTakePresets = FindNextNonEmptyTablePosition(currTablePosition);

                if (tablePositionToTakePresets == currTablePosition)
                {
                    winningElf = currTablePosition + 1; //index is zero-based
                } else
                {
                    _elfs[currTablePosition] += _elfs[tablePositionToTakePresets];

                    Console.WriteLine($"Elf {currTablePosition} took {_elfs[tablePositionToTakePresets]} presents from elf {tablePositionToTakePresets} and now has {_elfs[currTablePosition]} presents");

                    _elfs[tablePositionToTakePresets] = 0;
                }

                currTablePosition = (currTablePosition + 1) % INPUT;
            }

            return winningElf.ToString();
        }

        private int FindNextNonEmptyTablePosition(int currTablePosition)
        {
            int positionToSearch = (currTablePosition + 1) % INPUT;

            while(_elfs[positionToSearch] == 0)
            {
                positionToSearch = (positionToSearch + 1) % INPUT;
            }

            return positionToSearch;
        }

        public string SolvePuzzlePart2()
        {
            var elves = Enumerable.Range(1, INPUT).Select(id => new Elf(id)).ToList();
            var left = new LinkedList<Elf>();
            var right = new LinkedList<Elf>();

            int half = elves.Count / 2;
            for (int i = 0; i < elves.Count; i++)
            {
                if (i < half)
                    left.AddLast(elves[i]);
                else
                    right.AddLast(elves[i]);
            }

            while (left.Count + right.Count != 1)
            {
                Elf e = left.First.Value;
                left.Remove(e);
                if (left.Count == right.Count)
                    left.RemoveLast();
                else
                    right.RemoveFirst();
                right.AddLast(e);
                e = right.First.Value;
                right.Remove(e);
                left.AddLast(e);
            }

            return left.First.Value.Id.ToString();
        }


        internal sealed class Elf
        {
            public int Id { get; }

            public int Presents { get; set; }

            public Elf(int id)
            {
                Presents = 1;
                Id = id;
            }
        }
    }
}
