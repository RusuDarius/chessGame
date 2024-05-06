namespace ChessLogic
{
    public class EnPessant : Move
    {
        public override MoveType Type => MoveType.EnPessant;

        public override Position FromPos { get; }

        public override Position ToPos { get; }

        private readonly Position capturedPawnPosition;

        public EnPessant(Position fromPos, Position toPos)
        {
            FromPos = fromPos;
            ToPos = toPos;
            capturedPawnPosition = new Position(fromPos.Row, toPos.Column);
        }

        public override void Execute( Board board )
        {
            new NormalMove(FromPos, ToPos).Execute(board);
            board[capturedPawnPosition] = null;
        }
    }
}
