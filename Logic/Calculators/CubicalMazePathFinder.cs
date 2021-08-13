using AOC2016.Logic.Models;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Logic.Calculators
{
    public class CubicalMazePathFinder
    {
        public int FindMinNumOfStepsForPoints(CubicalMaze maze,
            int sourceX,
            int sourceY,
            int destinationX, int destinationY)
        {

            var path = new CubicalMazePath();

            int numOfSteps = 0;

            int currX = sourceX;
            int currY = sourceY;

            path.Points.Add(new MazePoint(currX, currY));

            while(currX != destinationX || currY != destinationY)
            {
                if (currY < destinationY && !maze[currX, currY + 1])
                {
                    currY++;
                    path.Points.Add(new MazePoint(currX, currY));
                    numOfSteps++;

                } else if (currX < destinationX && !maze[currX + 1, currY])
                {
                    currX++;
                    path.Points.Add(new MazePoint(currX, currY));
                    numOfSteps++;

                } else
                {
                    throw new Exception("Couldn't find a solution for this");
                }

                maze.Show(path);
            }

            return numOfSteps;
        }
    }
}
