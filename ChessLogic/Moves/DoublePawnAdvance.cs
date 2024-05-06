namespace ChessLogic
{
    public class DoublePawnAdvance : Move
    {
        public override MoveType Type => MoveType.DoublePawnAdvance;

        public override Position FromPos { get; }
        public override Position ToPos { get; }

        private readonly Position skippedPos;

        public DoublePawnAdvance(Position fromPos, Position toPos)
        {
            FromPos = fromPos;
            ToPos = toPos;
            skippedPos = new Position((fromPos.Row + toPos.Row) / 2, fromPos.Column);
        }

        // get moving player
        // store the skipped pos in the board
        // execute the move 
        public override void Execute( Board board )
        {
            Player player = board[FromPos].Color;
            board.setPawnSkippedPosition(player, skippedPos);
            new NormalMove(FromPos, ToPos);
        }
    }
}
