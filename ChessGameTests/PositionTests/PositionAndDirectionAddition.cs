using ChessLogic;

namespace ChessGameTests.PositionTests
{
    public class PositionAndDirectionAddition
    {
        [Fact]
        public void PlusOperator_AdditionOfPositionAndDirection_ReturnsPosition()
        {
            // Arrange
            Position position = new Position(2, 5);
            Direction direction = new Direction(1, 2);

            // Act
            Position result = position + direction;

            // Assert
            Assert.Equal(3, result.Row);
            Assert.Equal(7, result.Column);
        }
    }
}
