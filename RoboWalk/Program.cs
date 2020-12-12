using System;
using System.Linq;
using RoboWalk.Interfaces;

namespace RoboWalk
{
    class Program
    {
        static void Main(string[] args)
        {
            if (!int.TryParse(Console.ReadLine(), out var width))
                return;
            if (!int.TryParse(Console.ReadLine(), out var height))
                return;

            if (!int.TryParse(Console.ReadLine(), out var x))
                return;
            if (!int.TryParse(Console.ReadLine(), out var y))
                return;
            var directionString = Console.ReadLine();
            
            IRoom room = new Room(width, height);
            IRobot robot = new Robot(room);

            if (robot.SetPosition(x, y, GetDirection(directionString)))
            {
                var newPosition = robot.ProcessCommands(Console.ReadLine());
                Console.WriteLine(newPosition);
            }
        }

        static Direction GetDirection(string input) =>
            input.ToUpper()[0].ToString() switch
            {
                "N" => Direction.N,
                "E" => Direction.E,
                "S" => Direction.S,
                "W" => Direction.W,
                _ => Direction.N
            };
    }
}