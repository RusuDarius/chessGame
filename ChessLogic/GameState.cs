namespace ChessLogic
{
    public class GameState
    {
        public Board? Board { get; }
        public Player CurrentPlayer { get; private set; }
        public Result Result { get; private set; } = null;

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

            // Store all the moves possible
            IEnumerable<Move> moveCandidates =  piece.GetMoves(pos, Board);
            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        public void MakeMove(Move move)
        {
            move.Execute(Board);
            CurrentPlayer = CurrentPlayer.Opponent();
            CheckForGameOver();
        }

        // For verifying checkmate / stalemate, first generate all moves possible and filter the legal ones
        public IEnumerable<Move> AllLegalMovesFor(Player player)
        {
            IEnumerable<Move> moveCandidates = Board.PiecePositionsFor(player).SelectMany(pos =>
            {
                Piece piece = Board[pos];
                return piece.GetMoves(pos, Board);
            });

            return moveCandidates.Where(move => move.IsLegal(Board));
        }

        private void CheckForGameOver()
        {
            if (!AllLegalMovesFor(CurrentPlayer).Any())
            {
                if(Board.IsInCheck(CurrentPlayer))
                {
                    Result = Result.Win(CurrentPlayer.Opponent());
                }
                else
                {
                    Result = Result.Draw(EndReason.Stalemate);
                }
            }
        }

        public bool IsGameOver()
        {
            return Result != null;
        }
    }
}
