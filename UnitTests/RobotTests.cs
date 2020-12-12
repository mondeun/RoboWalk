using NSubstitute;
using RoboWalk;
using RoboWalk.Interfaces;
using Xunit;

namespace UnitTests
{
    public class RobotTests
    {
        private readonly IRoom _room;
        private IRobot _sut;

        public RobotTests()
        {
            _room = Substitute.For<Room>(3, 3);
        }
        
        [Theory]
        [InlineData(0, 0)]
        [InlineData(1, 1)]
        [InlineData(2, 2)]
        public void PlaceRobot_InBounds_PositionOk(int x, int y)
        {
            _sut = Substitute.For<Robot>(_room);

            var result = _sut.SetPosition(x, y, Direction.N);
            
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(-1, 0)]
        [InlineData(1, 4)]
        public void PlaceRobot_OutOfBounds_PositionNotOk(int x, int y)
        {
            _sut = Substitute.For<Robot>(_room);

            var result = _sut.SetPosition(x, y, Direction.N);
            
            Assert.False(result);
        }

        [Fact]
        public void ProcessCommand_WithNoCollision()
        {
            _sut = Substitute.For<Robot>(_room);
            _sut.SetPosition(1, 1, Direction.N);
            const string query = "FRFRFRFFLFLR";
            const string expected = "Report: 0 2 S";

            var result = _sut.ProcessCommands(query);
            
            Assert.Equal(expected, result);
        }
        
        [Fact]
        public void ProcessCommand_WithCollision()
        {
            _sut = Substitute.For<Robot>(_room);
            _sut.SetPosition(1, 1, Direction.N);
            const string query = "FFLFLF";
            const string expected = "Report: 0 1 S";

            var result = _sut.ProcessCommands(query);
            
            Assert.Equal(expected, result);
        }
    }
}