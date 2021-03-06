﻿using System.Collections.Generic;

namespace MarsRoverKata.Domain
{
    public class Grid : INavigator
    {
        private const int MaxHeight = 10;
        private const int MaxWidth = 10;
        private List<Coordinate> _obstacles = new List<Coordinate>();

        public Grid(List<Coordinate> obstacles)
        {
            _obstacles = obstacles;
        }

        public Grid()
        {
        }

        public Coordinate NextCoordinateFor(Direction direction, Coordinate coordinate)
        {
            int y = coordinate.Y;
            int x = coordinate.X;
            if (direction == Direction.North)
            {
                y = (y + 1) % MaxHeight;
            }
            if (direction == Direction.East)
            {
                x = (x + 1) % MaxWidth;
            }

            if (direction == Direction.West)
            {
                x = (x > 0) ? x - 1 : MaxWidth - 1;
            }

            if (direction == Direction.South)
            {
                y = (y > 0) ? y - 1 : MaxWidth - 1;
            }

            var newCoordinate = new Coordinate(x, y);
            var obstacleIndex = _obstacles.FindIndex(obstacle => obstacle.X == x && obstacle.Y == y);

            if (obstacleIndex >= 0)
            {
                return coordinate;
            }

            return newCoordinate;
        }
    }
}