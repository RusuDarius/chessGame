using ChessLogic;

namespace ChessGameTests.PositionTests
{
    public class PositionOverloadedOperatorsTests
    {
        [Fact]
        public void EqualityOperator_PositionsAreEqual_ReturnsTrue()
        {
            // Arrange
            Position pos1 = new Position(3, 4);
            Position pos2 = new Position(3, 4);

            // Act

            //Assert
            Assert.True(pos1 == pos2);
        }

        [Fact]
        public void EqualityOperator_PositionsAreEqual_ReturnsFalse()
        {
            // Arrange
            Position pos1 = new Position(2, 7);
            Position pos2 = new Position(3, 4);

            // Act

            //Assert
            Assert.False(pos1 == pos2);
        }


        // !=
        [Fact]
        public void InequalityOperator_PositionsAreNotEqual_ReturnsTrue()
        {
            // Arrange
            Position pos1 = new Position(3, 7);
            Position pos2 = new Position(2, 4);

            // Act

            //Assert
            Assert.True(pos1 != pos2);
        }

        [Fact]
        public void InequalityOperator_PositionsAreNotEqual_ReturnsFalse()
        {
            // Arrange
            Position pos1 = new Position(3, 7);
            Position pos2 = new Position(3, 7);

            // Act

            //Assert
            Assert.False(pos1 != pos2);
        }
    }
}
