namespace RoboWalk.Interfaces
{
    public interface IRobot
    {
        bool SetPosition(int x, int y, Direction orientation);
        string ProcessCommands(string query);
    }
}