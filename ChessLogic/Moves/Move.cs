namespace ChessLogic
{
    public abstract class Move
    {
        public abstract MoveType Type { get; }
        public abstract Position FromPos { get; }
        public abstract Position ToPos { get; }
        public abstract void Execute( Board board );

        // Validates that the following move does not leave the king in check
        public virtual bool IsLegal(Board board)
        {
            Player player = board[FromPos].Color;
            Board boardCopy = board.Copy();
            Execute(boardCopy);
            return !boardCopy.IsInCheck(player);
        }
    }
}
