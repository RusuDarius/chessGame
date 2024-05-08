using ChessLogic;

namespace ChessGameTests.DirectionTests
{
    public class DirectionCombinationTest
    {
        [Fact]
        public void AdditionOperator_AddTwoDirections_ReturnsCombinedDirection()
        {
            // Arrange
            Direction dir1 = new Direction(1, 2);
            Direction dir2 = new Direction(-1, 1);

            // Act
            Direction result = dir1 + dir2;

            // Assert
            Assert.Equal(0, result.RowDelta);
            Assert.Equal(3, result.ColumnDelta);
        }

        [Fact]
        public void AditionOperator_AddTwoDirections_ReturnsSameDirection()
        {
            // Arrange
            Direction dir1 = new Direction(2, 3);
            Direction dir2 = new Direction(0, 0);

            // Act
            Direction result = dir1 + dir2;

            // Assert
            Assert.Equal(dir1.RowDelta, result.RowDelta);
            Assert.Equal(dir1.ColumnDelta, result.ColumnDelta);
        }
    }
}
