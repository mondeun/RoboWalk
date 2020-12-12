using System;
using RoboWalk.Interfaces;

namespace RoboWalk
{
    public class Room : IRoom
    {
        private readonly int _width;
        private readonly int _height;

        public Room(int width, int height)
        {
            _width = Math.Abs(width);
            _height = Math.Abs(height);
        }
        
        public bool IsPositionWithinBoundary(int x, int y)
        {
            return x >= 0 && x <= _width - 1 &&
                   y >= 0 && y <= _height - 1;
        }
    }
}