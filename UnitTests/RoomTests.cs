using NSubstitute;
using RoboWalk;
using RoboWalk.Interfaces;
using Xunit;

namespace UnitTests
{
    public class RoomTests
    {
        private IRoom _sut;

        [Theory]
        [InlineData(1, 1, 0, 0)]
        [InlineData(2, 2, 1, 1)]
        [InlineData(5, 5, 3, 3)]
        public void CheckIfMoveIsPossible_isOk(int w, int h, int x, int y)
        {
            _sut = Substitute.For<Room>(w, h);

            var result = _sut.IsPositionWithinBoundary(x, y);
            
            Assert.True(result);
        }
        
        [Theory]
        [InlineData(1, 1, 1, 2)]
        [InlineData(2, 2, -1, 1)]
        [InlineData(5, 5, 6, 3)]
        public void CheckIfMoveIsPossible_isNotOk(int w, int h, int x, int y)
        {
            _sut = Substitute.For<Room>(w, h);

            var result = _sut.IsPositionWithinBoundary(x, y);
            
            Assert.False(result);
        }
    }
}