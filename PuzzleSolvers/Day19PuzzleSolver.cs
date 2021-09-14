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
            throw new NotImplementedException();
        }
    }
}
