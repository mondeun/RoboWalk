using System;
using RoboWalk.Interfaces;

namespace RoboWalk
{
    public class Room : IRoom
    {
        private readonly char[,] _floor;

        public Room(int width, int height)
        {
            _floor = new char[Math.Abs(width), Math.Abs(height)];
            _floor.Initialize();
        }
        
        public bool IsPositionWithinBoundary(int x, int y)
        {
            return x >= 0 && x <= _floor.GetLength(0) - 1 &&
                   y >= 0 && y <= _floor.GetLength(1) - 1;
        }
    }
}