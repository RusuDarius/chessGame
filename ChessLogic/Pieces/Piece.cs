namespace ChessLogic
{
    public abstract class Piece
    {
        public abstract PieceType Type { get; }
        public abstract Player Color { get; }
        public bool HasMoved { get; set; } = false;
        public abstract Piece Copy();

        public abstract IEnumerable<Move> GetMoves( Position fromPos, Board board );

        // for Rook, Bishop, Queen
        protected IEnumerable<Position> MovePositionsInDir( Position fromPos, Board board, Direction dir )
        {
            for(Position pos = fromPos + dir; Board.IsInside(pos); pos+=dir)
            {
                if(board.IsEmpty(pos))
                {
                    yield return pos;
                    continue;
                }

                Piece piece = board[pos];

                if(piece.Color != Color)
                {
                    yield return pos;
                }

                yield break;
            }
        }

        // collect reachable positions in all given directions
        protected IEnumerable<Position> MovePositioninDirs(Position from,  Board board, Direction[] dirs) 
        { 
            return dirs.SelectMany(dir => MovePositionsInDir(from, board, dir));
        }

        public virtual bool CanCaptureOpponentKing(Position fromPos, Board board)
        {
            return GetMoves(fromPos, board).Any(move =>
            {
                Piece piece = board[move.ToPos];
                return piece != null && piece.Type == PieceType.King;
            });
        }
    }
}
