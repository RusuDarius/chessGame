using ChessLogic;

namespace ChessGameTests
{
    public class ConcretePiece : Piece
    {

        public override PieceType Type { get; }

        public override Player Color { get; }

        public new bool HasMoved { get; } = false;

        public ConcretePiece(PieceType type, Player color, bool hasMoved)
        {
            Type = type;
            Color = color;
            HasMoved = hasMoved;
        }

        public override Piece Copy()
        {
            throw new NotImplementedException();
        }

        public override IEnumerable<Move> GetMoves( Position fromPos, Board board )
        {
            throw new NotImplementedException();
        }
    }
}
