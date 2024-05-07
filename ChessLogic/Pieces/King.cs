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

        // For validating that the rook didn't move previously
        // Don't check for right color/piece because we invoke this method on the original pos of a rook
        private static bool IsUnmovedRook(Position pos, Board board)
        {
            if(board.IsEmpty(pos))
            {
                return false;
            }

            Piece piece = board[pos];
            return (piece.Type == PieceType.Rook && !piece.HasMoved);
        }

        // Checks if squares are empty (for castling)
        private static bool AllEmpty(IEnumerable<Position> positions, Board board)
        {
            return positions.All(pos => board.IsEmpty(pos));
        }

        // If king has moved then false
        // Create pos where rook must be & positions array for pieces between king & rook
        // True if rook didn't move & betweenPositions are empty
        private bool CanCastleKingSide(Position kingPos, Board board)
        {
            if(HasMoved)
            {
                return false;
            }

            Position rookPos = new Position(kingPos.Row, 7);
            Position[] betweenPositions = [new(kingPos.Row, 5), new(kingPos.Row, 6)];

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
        }

        private bool CanCastleQueenSide(Position kingPos, Board board)
        {
            if(HasMoved)
            {
                return false;
            }

            Position rookPos = new Position(kingPos.Row, 0);
            Position[] betweenPositions = new Position[] { new(kingPos.Row, 1), new(kingPos.Row, 2), new(kingPos.Row, 3) };

            return IsUnmovedRook(rookPos, board) && AllEmpty(betweenPositions, board);
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

            // Add castle moves to GetMoves to generate them if possible
            if(CanCastleKingSide(fromPos, board))
            {
                yield return new Castle(MoveType.CastleKingSide, fromPos);
            }

            if(CanCastleQueenSide(fromPos, board))
            {
                yield return new Castle(MoveType.CastleQueenSide, fromPos);
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
