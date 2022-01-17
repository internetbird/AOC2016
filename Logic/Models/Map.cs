using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace AOC2016.Logic.Models
{
    public class Map
    {
        private Dictionary<int, Point> _pointOfInterst = new Dictionary<int, Point>();
        private MapPoint[,] _map;

        public Map(string[] mapLines)
        {
            if (mapLines == null || mapLines.Length == 0)
            {
                throw new ArgumentException("Non empty map lines should be provided");
            }

            InitializeMap(mapLines);

        }

        public Point GetPointOfInterest(int pointIndex) => _pointOfInterst[pointIndex];
      
        public int FindShortestDistanceBetween(Point point1, Point point2)
        {
            if (point1 == point2) return 0;

            var shortestDistanceDict = new Dictionary<Point, int>();
            var pointsToScanQueue = new Queue<Point>();
            pointsToScanQueue.Enqueue(point1);
            shortestDistanceDict.Add(point1, 0);

            while(pointsToScanQueue.Any())
            {
                var pointToScan = pointsToScanQueue.Dequeue();
                List<Point> reachablePoints = GetAllReachablePointsFrom(pointToScan);

                int reachablePointDistance = shortestDistanceDict[pointToScan] + 1;

                foreach (Point reachablePoint in reachablePoints)
                {
                    if (!shortestDistanceDict.ContainsKey(reachablePoint))
                    {
                        if (reachablePoint == point2) //Reached destination  
                        {
                            return reachablePointDistance;
                        }

                        shortestDistanceDict.Add(reachablePoint, reachablePointDistance);
                        pointsToScanQueue.Enqueue(reachablePoint);
                    }
                }
            } 

            return 0;
        }

        private List<Point> GetAllReachablePointsFrom(Point pointToScan)
        {
           var reachablePoints = new List<Point>();

            //Add right neighbourd
           if (pointToScan.X < (_map.GetLength(1) - 1))
            {
                if (!_map[pointToScan.Y, pointToScan.X + 1].IsWall)
                {
                    reachablePoints.Add(new Point(pointToScan.X + 1, pointToScan.Y));
                }
            }

            //Add left neigbour
            if (pointToScan.X > 0)
            {
                if (!_map[pointToScan.Y, pointToScan.X - 1].IsWall)
                {
                    reachablePoints.Add(new Point(pointToScan.X - 1, pointToScan.Y));
                }
            }
            //Add top neighbour
            if (pointToScan.Y > 0)
            {
                if (!_map[pointToScan.Y - 1, pointToScan.X].IsWall)
                {
                    reachablePoints.Add(new Point(pointToScan.X, pointToScan.Y - 1));
                }
            }

            //Add bottom neighbour
            if (pointToScan.Y < (_map.GetLength(1) - 1))
            {
                if (!_map[pointToScan.Y + 1, pointToScan.X].IsWall)
                {
                    reachablePoints.Add(new Point(pointToScan.X, pointToScan.Y + 1));
                }
            }

            return reachablePoints;
        }

        private void InitializeMap(string[] mapLines)
        {
            int numOfColumns = mapLines[0].Length;
            int numOfRows = mapLines.Length;

            _map = new MapPoint[numOfRows, numOfColumns];

            for (int i = 0; i < numOfRows; i++)
            {
                string currRow = mapLines[i];

                for (int j = 0; j < numOfColumns; j++)
                {
                    var mapPoint = new MapPoint();
                    mapPoint.IsWall = (currRow[j] == '#');
                    _map[i, j] = mapPoint;

                    if (int.TryParse(currRow[j].ToString(), out int poiVal) )
                    {
                        _pointOfInterst.Add(poiVal, new Point(j, i));
                    }
                }
            }
        }
    }
}
