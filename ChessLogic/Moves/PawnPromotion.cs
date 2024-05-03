namespace ChessLogic
{
    // Will refer to row 0 & row 7 on the board as promotion rows
    public class PawnPromotion : Move
    {
        public override MoveType Type => MoveType.PawnPromotion;

        public override Position FromPos { get; }

        public override Position ToPos { get; }

        // For the new piece the pawn will transform into
        private readonly PieceType newType;

        public PawnPromotion(Position from, Position to, PieceType newType)
        {
            FromPos = from;
            ToPos = to;
            this.newType = newType;
        }

        // Returns a new piece with new type & the given color
        private Piece CreatePromotionPiece(Player color)
        {
            return newType switch
            {
                PieceType.Knight => new Knight(color),
                PieceType.Bishop => new Bishop(color),
                PieceType.Rook => new Rook(color),
                _ => new Queen(color),
            };
        }

        // Take the pawn at the given pos, remove it, create the new piece of the same color,
        // HasMoved=true because it goes as a valid move, place the new piece at the position
        public override void Execute( Board board )
        {
            Piece pawn = board[FromPos];
            board[FromPos] = null;

            Piece promotionPiece = CreatePromotionPiece(pawn.Color);
            promotionPiece.HasMoved = true;
            board[ToPos] = promotionPiece;
        }
    }
}
