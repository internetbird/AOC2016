using AOC2016.Logic;
using System;
using System.Collections.Generic;
using System.Text;

namespace AOC2016.Models
{
    public class CoordinatesRobot
    {
        private int x_coordinate;
        private int y_coordinate;
        private Direction _faceDirection;

        public CoordinatesRobot()
        {
            x_coordinate = 0;
            y_coordinate = 0;
            _faceDirection = Direction.North;
        }
      
        public void FollowInstruction(WalkInstruction instruction)
        {
            Turn(instruction.SideToTurn);
            Walk(instruction.BlocksToWalk);
          
        }

        public void Move(Direction directionToMove)
        {
            switch (directionToMove)
            {
                case Direction.North:
                    y_coordinate++;
                    break;
                case Direction.South:
                    y_coordinate--;
                    break;
                case Direction.East:
                    x_coordinate++;
                    break;
                case Direction.West:
                    x_coordinate--;
                    break;
            }
        }

        public int GetTaxiCabDistance()
        {
            return Math.Abs(x_coordinate) + Math.Abs(y_coordinate);
        }

        public string GetCoordinateString()
        {
            return $"{x_coordinate},{y_coordinate}";
        }

        private void Turn(Side sideToTurn)
        {
            if (sideToTurn == Side.Right)
            {
                switch (_faceDirection)
                {
                    case Direction.North:
                        _faceDirection = Direction.East;
                        break;
                    case Direction.South:
                        _faceDirection = Direction.West;
                        break;
                    case Direction.East:
                        _faceDirection = Direction.South;
                        break;
                    case Direction.West:
                        _faceDirection = Direction.North;
                        break;
                }

            }
            else //left 
            {
                switch (_faceDirection)
                {
                    case Direction.North:
                        _faceDirection = Direction.West;
                        break;
                    case Direction.South:
                        _faceDirection = Direction.East;
                        break;
                    case Direction.East:
                        _faceDirection = Direction.North;
                        break;
                    case Direction.West:
                        _faceDirection = Direction.South;
                        break;
                }
            }
        }

        private void Walk(int blocksToWalk)
        {
            switch(_faceDirection)
            {
                case Direction.North:
                    y_coordinate += blocksToWalk;
                    break;
                case Direction.South:
                    y_coordinate -= blocksToWalk;
                    break;
                case Direction.East:
                    x_coordinate += blocksToWalk;
                    break;
                case Direction.West:
                    x_coordinate -= blocksToWalk;
                    break;
            }
        }

    }
}
