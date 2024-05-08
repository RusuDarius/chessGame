using ChessLogic;
using Xunit;

namespace ChessGameTests.BoardTests
{
    public class EmptyOrInsideTest
    {
        [Fact]
        public void IsInside_ReturnsTrue_WhenPositionIsInsideBoard()
        {
            // Arrange
            var board = new Board();
            var pos = new Position(3, 4);

            // Act
            var result = Board.IsInside(pos);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsInside_ReturnsFalse_WhenPositionIsOutsideBoard()
        {
            // Arrange
            var board = new Board();
            var pos = new Position(8, 2); // Outside position

            // Act
            var result = Board.IsInside(pos);

            // Assert
            Assert.False(result);
        }

        [Fact]
        public void IsEmpty_ReturnsTrue_WhenPositionIsEmpty()
        {
            // Arrange
            var board = new Board();
            var emptyPos = new Position(3, 4); // Empty position

            // Act
            var result = board.IsEmpty(emptyPos);

            // Assert
            Assert.True(result);
        }

        [Fact]
        public void IsEmpty_ReturnsFalse_WhenPositionIsOccupied()
        {
            // Arrange
            var board = new Board();
            var occupiedPos = new Position(0, 0); // Occupied position
            board[occupiedPos] = new ConcretePiece(PieceType.Rook, Player.Black, hasMoved: false);

            // Act
            var result = board.IsEmpty(occupiedPos);

            // Assert
            Assert.False(result);
        }
    }
}
