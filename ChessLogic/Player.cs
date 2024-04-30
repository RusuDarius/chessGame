namespace ChessLogic
{
    public enum Player
    {
        Black,
        White,
        None
    }

    public static class PlayerExtensions
    {
        public static Player Opponent(this Player player)
        {
            return player switch
            {
                Player.Black => Player.White,
                Player.White => Player.Black,
                _ => Player.None,
            };
        }
    }
}
