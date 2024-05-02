namespace ChessLogic
{
    public class Knight : Piece
    {
        public override PieceType Type => PieceType.Knight;

        public override Player Color { get; }

        public Knight(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            Knight copy = new Knight(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private static IEnumerable<Position> PotentialToPositions(Position fromPos)
        {
            foreach(Direction verticalDir in new Direction[] {Direction.North, Direction.South})
            {
                foreach(Direction horizontalDir in new Direction[] {Direction.East, Direction.West})
                {
                    yield return fromPos + 2 * verticalDir + horizontalDir;
                    yield return fromPos + 2 * horizontalDir + verticalDir;
                }
            }
        }

        private IEnumerable<Position> MovePositions(Position fromPos, Board board)
        {
            return PotentialToPositions(fromPos).Where(pos => Board.IsInside(pos) && (board.IsEmpty(pos) || board[pos].Color != Color));
        }

        public override IEnumerable<Move> GetMoves( Position fromPos, Board board )
        {
            return MovePositions(fromPos, board).Select(to => new NormalMove(fromPos, to));
        }
    }
}
