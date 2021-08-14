using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;

namespace AOC2016.Logic.Calculators
{
    public class CubicalMazePathFinder
    {

        private CubicalMaze _maze;

        public CubicalMazePathFinder(CubicalMaze maze)
        {
            _maze = maze;
        }
       
        public CubicalMazePathFinderResult FindPath(int sourceX, int sourceY,int destinationX, int destinationY)
        {
            var path = new CubicalMazePath();

            int currX = sourceX;
            int currY = sourceY;

            path.Points.Add(new MazePoint(currX, currY));

            var random = new Random();

            while(currX != destinationX || currY != destinationY)
            {
                List<CubicalMazeMove> validMoves = GetAllValidMoves(currX, currY, path);

                if (validMoves.Count > 0)
                {
                    int randomValidMoveIndex = random.Next(0, validMoves.Count);
                    CubicalMazeMove randomValidMove = validMoves[randomValidMoveIndex];

                    switch (randomValidMove)
                    {
                        case CubicalMazeMove.Up:
                            currY--;
                            break;
                        case CubicalMazeMove.Down:
                            currY++;
                            break;
                        case CubicalMazeMove.Left:
                            currX--;
                            break;
                        case CubicalMazeMove.Right:
                            currX++;
                            break;
                        default:
                            break;
                    }

                    path.Points.Add(new MazePoint(currX, currY));

                } else
                {
                   return new CubicalMazePathFinderResult { Success = false, Path = path };
                }
            }

            return new CubicalMazePathFinderResult { Success = true, Path = path };
        }

        private List<CubicalMazeMove> GetAllValidMoves(int currX, int currY, CubicalMazePath path)
        {
            var validMoves = new List<CubicalMazeMove>();

            if (currX < _maze.Size && !_maze[currX + 1, currY] && !path.ContainsPoint(currX+1, currY))
            {
                validMoves.Add(CubicalMazeMove.Right);
            }

            if (currX > 0 && !_maze[currX - 1, currY] && !path.ContainsPoint(currX - 1, currY))
            {
                validMoves.Add(CubicalMazeMove.Left);
            }

            if (currY < _maze.Size && !_maze[currX, currY + 1]  && !path.ContainsPoint(currX, currY + 1))
            {
                validMoves.Add(CubicalMazeMove.Down);
            }

            if (currY > 0 && !_maze[currX, currY - 1] && !path.ContainsPoint(currX, currY - 1))
            {
                validMoves.Add(CubicalMazeMove.Up);
            }

            return validMoves;
        }
    }
}
