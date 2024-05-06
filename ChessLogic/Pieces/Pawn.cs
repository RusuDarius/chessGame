namespace ChessLogic
{
    public class Pawn : Piece
    {
        public override PieceType Type => PieceType.Pawn;
        public override Player Color { get; }

        private readonly Direction forward;

        public Pawn(Player color)
        {
            Color = color;

            if(color == Player.White)
            {
                forward = Direction.North;
            }
            else if (color == Player.Black)
            {
                forward = Direction.South;
            }
        }

        public override Piece Copy()
        {
            Pawn copy = new Pawn(Color) { HasMoved = HasMoved };
            return copy;
        }

        public static bool CanMoveTo(Position pos, Board board)
        {
            return Board.IsInside(pos) && board.IsEmpty(pos);
        }

        public bool CanCaptureAt(Position pos, Board board)
        {
            if(!Board.IsInside(pos) || board.IsEmpty(pos))
            {
                return false;
            }

            return board[pos].Color != Color;
        }

        // Creates 4 promotion moves
        private static IEnumerable<Move> PromotionMoves(Position from, Position to)
        {
            yield return new PawnPromotion(from, to, PieceType.Knight);
            yield return new PawnPromotion(from, to, PieceType.Bishop);
            yield return new PawnPromotion(from, to, PieceType.Rook);
            yield return new PawnPromotion(from, to, PieceType.Queen);
        }

        public IEnumerable<Move> ForwardMoves( Position fromPos, Board board )
        {
            Position oneMovePosition = fromPos + forward;

            if (CanMoveTo(oneMovePosition, board))
            {
                // Check if the pawn reaches promotion square
                if (oneMovePosition.Row == 0 || oneMovePosition.Row == 7)
                {
                    // generate the 4 promotion moves
                    foreach (Move promMove in PromotionMoves(fromPos, oneMovePosition))
                    {
                        yield return promMove;
                    }
                }
                else
                {
                    yield return new NormalMove(fromPos, oneMovePosition);
                }

                // For the 1st move of each pawn; en pessant later
                Position twoMovesPosition = oneMovePosition + forward;

                if (!HasMoved && CanMoveTo(twoMovesPosition, board))
                {
                    yield return new DoublePawnAdvance(fromPos, twoMovesPosition);
                }
            }
        }

        public IEnumerable<Move> DiagonalMoves(Position fromPos, Board board)
        {
            foreach(Direction dir in new Direction[] {Direction.East, Direction.West})
            {
                Position to = fromPos + forward + dir;

                if(to == board.GetPawnSkippedPosition(Color.Opponent()))
                {
                    yield return new EnPessant(fromPos, to);
                }
                // If a pawn can capture a piece
                else if (CanCaptureAt(to, board))
                {
                    // Check if it reaches promotion square
                    if (to.Row == 0 || to.Row == 7)
                    {
                        // if yes we return the promotin moves
                        foreach (Move promMove in PromotionMoves(fromPos, to))
                        {
                            yield return promMove;
                        }
                    }
                    else
                    {
                        yield return new NormalMove(fromPos, to);
                    }
                }
            }
        }

        public override IEnumerable<Move> GetMoves( Position fromPos, Board board )
        {
            return ForwardMoves(fromPos, board).Concat(DiagonalMoves(fromPos, board));
        }

        public override bool CanCaptureOpponentKing( Position fromPos, Board board )
        {
            return DiagonalMoves(fromPos, board).Any(move =>
            {
                Piece piece = board[move.FromPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}
