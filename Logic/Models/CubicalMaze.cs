using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class CubicalMaze
    {
        private bool[,] _maze;

        private int _size;
        private int _favoriteNum;

        public bool this[int x, int y]
        {
            get
            {
                return _maze[x, y];
            }
        }

        public CubicalMaze(int favoriteNumber, int mazeSize = 40)
        {
            _maze = new bool[mazeSize, mazeSize];
            _size = mazeSize;
            _favoriteNum = favoriteNumber;

            InitializeMazeState();
        }

        public void Show(CubicalMazePath path = null)
        {
            try
            {
                Console.Clear();
            }
            catch (Exception)
            {
               //Couldnot clear the console
            }
           

            for (int y = 0; y < _size; y++)
            {
             
                for (int x = 0; x < _size; x++)
                {
                    if (path != null && path.Points.Any(location => location.X == x && location.Y == y))
                    {
                        Console.ForegroundColor = ConsoleColor.Green;
                        Console.Write("O");
                        Console.ForegroundColor = ConsoleColor.White;

                    } else
                    {
                        Console.Write(_maze[x, y] ? "#" : ".");
                    }
                }
                Console.WriteLine();
            }
        }

        private void InitializeMazeState()
        {
            for (int x = 0; x < _size; x++)
            {
                for (int y = 0; y < _size; y++)
                {
                    _maze[x, y] = IsWall(x, y);
                }
            }
        }

        private bool IsWall(int x, int y)
        {
            int calculatedValue = (x * x + 3 * x + 2 * x * y + y + y * y) + _favoriteNum;

            string binaryString = Convert.ToString(calculatedValue, 2);
            int numOfOnes = binaryString.ToCharArray().Sum(digit => digit == '1' ? 1 : 0);

            return numOfOnes % 2 != 0;
        }
    }
}
