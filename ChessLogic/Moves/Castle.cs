namespace ChessLogic
{
    public class Castle : Move
    {
        public override MoveType Type { get; }

        public override Position FromPos { get; }

        public override Position ToPos { get; }

        private readonly Direction KingMovedirection;
        private readonly Position RookFromPos;
        private readonly Position RookToPos;

        public Castle(MoveType type, Position kingPos)
        {
            Type = type;
            FromPos = kingPos;

            if(type == MoveType.CastleKingSide)
            {
                KingMovedirection = Direction.East;
                ToPos = new Position(kingPos.Row, 6);

                // Rook moves from col 7 to col 5
                RookFromPos = new Position(kingPos.Row, 7);
                RookToPos = new Position(kingPos.Row, 5);
            }
            else if(type == MoveType.CastleQueenSide)
            {
                KingMovedirection = Direction.West;
                ToPos = new Position(kingPos.Row, 2);

                // Rook moves from col 0 to col 3
                RookFromPos = new Position(kingPos.Row, 0);
                RookToPos = new Position(kingPos.Row, 3);
            }
        }

        public override void Execute( Board board )
        {
            new NormalMove(FromPos, ToPos).Execute(board);
            new NormalMove(RookFromPos, RookToPos).Execute(board);
        }

        // override IsLegal to validate that castling is not putting the king in check or that the king is not already in check
        // To make sure king will not be in check, make a copy of the board and store king pos in the copy
        // Loop through the positions and check for check, if everything is good, we good to go.
        public override bool IsLegal( Board board )
        {
            Player player = board[FromPos].Color;

            if(board.IsInCheck(player))
            {
                return false;
            }

            Board copy = board.Copy();
            Position kingPositionInCopy = FromPos;

            for(int i=0; i<2; i++)
            {
                new NormalMove(kingPositionInCopy, kingPositionInCopy + KingMovedirection).Execute(copy);
                kingPositionInCopy += KingMovedirection;

                if(copy.IsInCheck(player))
                {
                    return false;
                }
            }
            return true;
        }
    }
}
