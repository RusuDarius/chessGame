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
    }
}
