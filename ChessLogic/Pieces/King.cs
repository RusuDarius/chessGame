namespace ChessLogic
{
    public class King : Piece
    {
        public override PieceType Type => PieceType.King;

        public override Player Color { get; }

        private static readonly Direction[] dirs = new Direction[]
        {
            Direction.East,
            Direction.North,
            Direction.South,
            Direction.West,
            Direction.NorthEast,
            Direction.NorthWest,
            Direction.SouthEast,
            Direction.SouthWest
        };

        public King(Player color)
        {
            Color = color;
        }

        public override Piece Copy()
        {
            King copy = new King(Color);
            copy.HasMoved = HasMoved;
            return copy;
        }

        private IEnumerable<Position> MovePositions(Position fromPos, Board board)
        {
            foreach (Direction dir in dirs)
            {
                Position to = fromPos + dir;

                if (!Board.IsInside(to))
                {
                    continue;
                }

                if (board.IsEmpty(to) || board[to].Color != Color)
                {
                    yield return to;
                }
            }
        }

        public override IEnumerable<Move> GetMoves( Position fromPos, Board board )
        {
            foreach(Position to in MovePositions(fromPos, board))
            {
                yield return new NormalMove(fromPos, to);
            }
        }

        public override bool CanCaptureOpponentKing( Position fromPos, Board board )
        {
            return MovePositions(fromPos, board).Any(to =>
            {
                Piece piece = board[to];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}
