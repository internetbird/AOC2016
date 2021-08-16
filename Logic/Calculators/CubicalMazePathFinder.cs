using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;

namespace AOC2016.Logic.Calculators
{
    public class CubicalMazePathFinder
    {

        private CubicalMaze _maze;
        private List<MazePoint> _visitedMazePoints;


        public CubicalMazePathFinder(CubicalMaze maze)
        {
            _maze = maze;
            _visitedMazePoints = new List<MazePoint>();
        }
       
        public CubicalMazePathFinderResult FindAllPaths(int sourceX, int sourceY,int destinationX, int destinationY)
        {

            var currentPoint = new MazePoint(sourceX, sourceY);
            _visitedMazePoints.Add(currentPoint);

            var successfulPaths = new List<CubicalMazePath>();

            // DrawPoint(currentPoint);

            while (sourceX != destinationX || sourceY != destinationY)
            {
                List<CubicalMazeMove> validMoves = GetAllValidMoves(sourceX, sourceY);

                if (validMoves.Any())
                {
                    foreach (CubicalMazeMove validMove in validMoves)
                    {
                        CubicalMazePathFinderResult subPathResult;

                        switch (validMove)
                        {
                            case CubicalMazeMove.Up:

                               subPathResult = FindAllPaths(sourceX, sourceY - 1, destinationX, destinationY);
                                if (subPathResult.Success)
                                {
                                    AddSuccessfulPath(currentPoint, successfulPaths, subPathResult);
                                }

                                break;
                            case CubicalMazeMove.Down:
                               subPathResult = FindAllPaths(sourceX, sourceY + 1, destinationX, destinationY);
                                if (subPathResult.Success)
                                {
                                    AddSuccessfulPath(currentPoint, successfulPaths, subPathResult);
                                }
                                break;
                            case CubicalMazeMove.Left:
                                subPathResult = FindAllPaths(sourceX - 1, sourceY, destinationX, destinationY);
                                if (subPathResult.Success)
                                {
                                    AddSuccessfulPath(currentPoint, successfulPaths, subPathResult);
                                }
                                break;
                            case CubicalMazeMove.Right:
                                subPathResult = FindAllPaths(sourceX + 1, sourceY, destinationX, destinationY);
                                if (subPathResult.Success)
                                {
                                    AddSuccessfulPath(currentPoint, successfulPaths, subPathResult);
                                }
                                break;
                            default:
                                break;
                        }
                    }

                } else 
                {
                    return new CubicalMazePathFinderResult { Success = false, Paths = new List<CubicalMazePath>() };
                }
            }

            return new CubicalMazePathFinderResult { Success = true, Paths = successfulPaths};
        }

        private static void AddSuccessfulPath(MazePoint currentPoint, List<CubicalMazePath> successfulPaths, CubicalMazePathFinderResult subPathResult)
        {
            foreach (var successfulSubPath in subPathResult.Paths)
            {

                var successFullPathPoints = new List<MazePoint> { currentPoint };
                successFullPathPoints.AddRange(successfulSubPath.Points);
                successfulPaths.Add(new CubicalMazePath { Points = successFullPathPoints });
            }
        }

        private void DrawPoint(MazePoint currentPoint)
        {
            Console.SetCursorPosition(currentPoint.X, currentPoint.Y);
            Console.ForegroundColor = ConsoleColor.Green;
            Console.Write("O");
        }

        private List<CubicalMazeMove> GetAllValidMoves(int currX, int currY)
        {
            var validMoves = new List<CubicalMazeMove>();

            if (currX < _maze.Size && !_maze[currX + 1, currY] && !IsPointVisited(currX+1, currY))
            {
                validMoves.Add(CubicalMazeMove.Right);
            }

            if (currX > 0 && !_maze[currX - 1, currY] && !IsPointVisited(currX - 1, currY))
            {
                validMoves.Add(CubicalMazeMove.Left);
            }

            if (currY < _maze.Size && !_maze[currX, currY + 1]  && !IsPointVisited(currX, currY + 1))
            {
                validMoves.Add(CubicalMazeMove.Down);
            }

            if (currY > 0 && !_maze[currX, currY - 1] && !IsPointVisited(currX, currY - 1))
            {
                validMoves.Add(CubicalMazeMove.Up);
            }

            return validMoves;
        }

        private bool IsPointVisited(int x, int y)
        {
            return _visitedMazePoints.Any(point => point.X == x && point.Y == y);
        }
    }
}
