using RoboWalk.Interfaces;

namespace RoboWalk
{
    public class Room : IRoom
    {
        private readonly char[,] _floor;

        public Room(int width, int height)
        {
            _floor = new char[width, height];
            _floor.Initialize();
        }
        
        public bool IsPositionWithinBoundary(int x, int y)
        {
            throw new System.NotImplementedException();
        }
    }
}