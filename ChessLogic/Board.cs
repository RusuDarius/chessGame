namespace ChessLogic
{
    public class Board
    {
        private readonly Piece[,] pieces = new Piece[8, 8];

        private readonly Dictionary<Player, Position> pawnSkipPositions = new Dictionary<Player, Position>
        {
            {Player.White, null },
            {Player.Black, null }
        };

        // access the board like a 2D array
        public Piece this[int row, int col]
        {
            get { return pieces[row, col]; }
            set { pieces[row, col] = value; }
        }

        // to use position object as index; unpacks given position and calls first indexer
        public Piece this[Position pos]
        {
            get { return this[pos.Row, pos.Column]; }
            set { this[pos.Row, pos.Column] = value; }
        }

        public Position GetPawnSkippedPosition(Player player)
        {
            return pawnSkipPositions[player];
        }

        // store skipped pos in dictionary
        public void setPawnSkippedPosition(Player player, Position pos)
        {
            pawnSkipPositions[player] = pos;
        }

        public static Board InitialBoardState()
        {
            Board board = new Board();
            board.AddStartPieces();
            return board;
        }

        public void AddStartPieces()
        {
            this[0, 0] = new Rook(Player.Black);
            this[0, 1] = new Knight(Player.Black);
            this[0, 2] = new Bishop(Player.Black);
            this[0, 3] = new Queen(Player.Black);
            this[0, 4] = new King(Player.Black);
            this[0, 5] = new Bishop(Player.Black);
            this[0, 6] = new Knight(Player.Black);
            this[0, 7] = new Rook(Player.Black);

            this[7, 0] = new Rook(Player.White);
            this[7, 1] = new Knight(Player.White);
            this[7, 2] = new Bishop(Player.White);
            this[7, 3] = new Queen(Player.White);
            this[7, 4] = new King(Player.White);
            this[7, 5] = new Bishop(Player.White);
            this[7, 6] = new Knight(Player.White);
            this[7, 7] = new Rook(Player.White);

            for (int col = 0; col < 8; col++)
            {
                this[1, col] = new Pawn(Player.Black);
                this[6, col] = new Pawn(Player.White);
            }
        }

        public static bool IsInside(Position pos)
        {
            return pos.Row >= 0 && pos.Row <= 7 && pos.Column >= 0 && pos.Column <= 7;
        }

        public bool IsEmpty(Position pos)
        {
            return this[pos] == null;
        }

        // Check for non-empty positions
        public IEnumerable<Position> PiecePositions()
        {
            for(int r=0; r<8; r++)
            {
                for( int c=0; c<8; c++)
                {
                    Position pos = new Position(r,c);
                    if(!IsEmpty(pos))
                    {
                        yield return pos;
                    }
                }
            }
        }

        // For positions of the pieces of the given player
        public IEnumerable<Position> PiecePositionsFor(Player player)
        {
            return PiecePositions().Where(pos => this[pos].Color == player);
        }

        public bool IsInCheck(Player player)
        {
            return PiecePositionsFor(player.Opponent()).Any(pos =>
            {
                Piece piece = this[pos];
                return piece.CanCaptureOpponentKing(pos, this);
            });
        }

        // Used for filtering the moves that leave the king in check (illegal)
        // Creates a copy of the board where the move will be made to check if it's legal(allied king not in check after it)
        public Board Copy()
        {
            Board copy = new Board();
            
            foreach(Position pos in PiecePositions())
            {
                copy[pos] = this[pos].Copy();
            }

            return copy;
        }
    }
}
