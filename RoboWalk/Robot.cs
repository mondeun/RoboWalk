﻿using System;
using System.Linq;
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
            if (_room.IsPositionWithinBoundary(x, y))
            {
                _x = x;
                _y = y;
                _orientation = orientation;

                return true;
            }

            return false;
        }

        public string ProcessCommands(string query)
        {
            foreach (var command in query.AsEnumerable())
            {
                switch (command)
                {
                    case 'L':
                        TurnLeft();
                        break;
                    case 'R':
                        TurnRight();
                        break;
                    case 'F':
                        WalkForward();
                        break;
                }
                
                Console.WriteLine($"{_x} {_y} {_orientation}");
            }

            return $"Report: {_x} {_y} {_orientation}";
        }
        
        

        private void TurnLeft()
        {
            if (_orientation == Direction.N)
                _orientation = Direction.W;
            else
                _orientation -= 1;
        }
        
        private void TurnRight()
        {
            if (_orientation == Direction.W)
                _orientation = Direction.N;
            else
                _orientation += 1;
        }

        private void WalkForward()
        {
            var dx = 0;
            var dy = 0;

            switch (_orientation)
            {
                case Direction.N:
                    dy = -1;
                    break;
                case Direction.E:
                    dx = 1;
                    break;
                case Direction.S:
                    dy = 1;
                    break;
                case Direction.W:
                    dx = -1;
                    break;
            }

            if (_room.IsPositionWithinBoundary(_x + dx, _y + dy))
            {
                _x += dx;
                _y += dy;
            }
        }
    }
}