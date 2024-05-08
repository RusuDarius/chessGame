using ChessLogic;
using FluentAssertions;

namespace ChessGameTests.DirectionTests
{
    public class DirectionScalingTest
    {
        public void ScalarOperation_ScaleDirection_ReturnsScaledDirection()
        {
            // Arrange
            Direction direction = new Direction(1, 2);
            int scalar = 4;

            // Act
            Direction result = scalar * direction;

            // Assert
            Assert.Equal(4, result.RowDelta);
            Assert.Equal(8, result.ColumnDelta);
        }

        [Fact]
        public void ScalarOperation_ScaleDirection_ReturnsZeroDirection()
        {
            // Arrange
            Direction direction = new Direction(2, 6);
            int scalar = 0;

            // Act
            Direction result = scalar * direction;

            // Assert
            Assert.Equal(0, result.RowDelta);
            Assert.Equal(0, result.ColumnDelta);
        }
    }
}
