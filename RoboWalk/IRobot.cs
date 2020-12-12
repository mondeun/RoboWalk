namespace RoboWalk
{
    public interface IRobot
    {
        void SetPosition(int x, int y, Direction orientation);
        void ProcessCommands(string query);
        string ReportPosition();
    }
}