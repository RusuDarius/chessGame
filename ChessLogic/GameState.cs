namespace ChessLogic
{
    public class GameState
    {
        public Board? Board { get; }
        public Player CurrentPlayer { get; private set; }

        // player + board as params because white starts first
        public GameState(Player player, Board board)
        {
            CurrentPlayer = player;
            Board = board;
        }

        // Checks for legal moves
        public IEnumerable<Move> LegalMovesForPiece(Position pos)
        {
            if (Board.IsEmpty(pos) || Board[pos].Color != CurrentPlayer)
            {
                return Enumerable.Empty<Move>();
            }

            Piece piece = Board[pos];
            return piece.GetMoves(pos, Board);
        }

        public void MakeMove(Move move)
        {
            move.Execute(Board);
            CurrentPlayer = CurrentPlayer.Opponent();
        }
    }
}
