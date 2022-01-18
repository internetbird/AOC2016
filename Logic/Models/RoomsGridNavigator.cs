using AOC2016.Models;
using AOC2016.Utility;
using System;
using System.Collections.Generic;
using System.Drawing;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class RoomsGridNavigator
    {

        private const int VaultRoomX = 3;
        private const int VaultRoomY = 3;
        private const int MaxGridIndex = 3;
        private readonly string _passcode;

        public RoomsGridNavigator(string passCode)
        {
            _passcode = passCode;
        }


        public string FindShortestPathToVault()
        {
            List<string> allPaths = FindAllPathsToVault(new Point(0, 0), string.Empty);

            if (allPaths.Any())
            {
                return allPaths.OrderBy(path => path.Length).First();
            }
            return string.Empty;
        }

        public int FindLongestPathLengthToVault()
        {
            List<string> allPaths = FindAllPathsToVault(new Point(0, 0), string.Empty);

            if (allPaths.Any())
            {
                return allPaths.OrderByDescending(path => path.Length).First().Length;
            }

            return -1;
        }


        /// <summary>
        /// Finds all the valid paths to the vault
        /// </summary>
        /// <param name="startPosition"></param>
        /// <returns>Valid paths to vault or NULL if not path is found</returns>
        private List<string> FindAllPathsToVault(Point startPosition, string pathToStartPosition)
        {
            var paths = new List<string>();

            if (startPosition.X == VaultRoomX && startPosition.Y == VaultRoomY)
            {
                return new List<string> { string.Empty };
            }

            List<Direction> allValidDirections = GetAllValidDirections(startPosition, pathToStartPosition);

            if (!allValidDirections.Any()) new List<string>();

            foreach (Direction direction in allValidDirections)
            {
               Point nextPosition =  GetNextPosition(startPosition, direction);
               char pathChar = GetPathChar(direction);

                List<string> subPaths = FindAllPathsToVault(nextPosition, pathToStartPosition + pathChar);

                foreach (string subPath in subPaths)
                {
                    paths.Add(pathChar + subPath);
                }
            }

            return paths;
        }

        private char GetPathChar(Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return 'U';
                case Direction.South:
                    return 'D';
                case Direction.West:
                    return 'L';
                case Direction.East:
                    return 'R';

            }
            return char.MinValue;
        }

        private Point GetNextPosition(Point currPosition, Direction direction)
        {
            switch (direction)
            {
                case Direction.North:
                    return new Point(currPosition.X, currPosition.Y - 1);
                case Direction.South:
                    return new Point(currPosition.X, currPosition.Y + 1);
                case Direction.East:
                    return new Point(currPosition.X + 1, currPosition.Y);
                case Direction.West:
                    return new Point(currPosition.X - 1, currPosition.Y);
                default:
                    return currPosition;
            }
        }

        private List<Direction> GetAllValidDirections(Point startPosition, string pathToStartPosition)
        {
            string md5Hash = CryptographyHelper.CreateMD5Hash(_passcode + pathToStartPosition).ToLower();
            var validDirections = new List<Direction>();

            if (startPosition.Y > 0 && IsDoorOpenForDirection(Direction.North, md5Hash))
            {
                validDirections.Add(Direction.North);
            }

            if (startPosition.Y < MaxGridIndex && IsDoorOpenForDirection(Direction.South, md5Hash))
            {
                validDirections.Add(Direction.South);
            }

            if (startPosition.X < MaxGridIndex && IsDoorOpenForDirection(Direction.East, md5Hash))
            {
                validDirections.Add(Direction.East);
            }

            if (startPosition.X > 0 && IsDoorOpenForDirection(Direction.West, md5Hash))
            {
                validDirections.Add(Direction.West);
            }
            return validDirections;
        }

        public bool IsDoorOpenForDirection(Direction direction, string md5Hash)
        {
            switch (direction)
            {
                case Direction.North:
                    return IsOpenCharacter(md5Hash[0]);
                case Direction.South:
                    return IsOpenCharacter(md5Hash[1]);
                case Direction.West:
                    return IsOpenCharacter(md5Hash[2]);
                case Direction.East:
                    return IsOpenCharacter(md5Hash[3]);
            }

            return false;
        }

        private bool IsOpenCharacter(char hashChar)
        {
            return hashChar >= 'b' && hashChar <= 'f';
        }
    }
}
