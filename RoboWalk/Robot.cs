using System;
using RoboWalk.Interfaces;

namespace RoboWalk
{
    public class Robot : IRobot
    {
        private int _x;
        private int _y;
        private Direction _orientation;
        private readonly IRoom _room;

        public Robot(IRoom room)
        {
            _room = room;
        }
        
        public bool SetPosition(int x, int y, Direction orientation)
        {
            throw new NotImplementedException();
        }

        public string ProcessCommands(string query)
        {
            throw new NotImplementedException();
        }

        private void TurnLeft()
        {
        }
        
        private void TurnRight()
        {
        }

        private void WalkForward()
        {
        }
    }
}