namespace Board
{
    abstract class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int movesQuantity { get; protected set; }
        public Chessboard chessboard { get; protected set; }

        public Piece(Chessboard chessboard, Color color)
        {
            this.chessboard = chessboard;
            this.color = color;
            position = null;
            movesQuantity = 0;
        }

        public void AddMovesQuantity()
        {
            movesQuantity++;
        }

        public void DeleteMovesQuantity()
        {
            movesQuantity--;
        }

        public bool HasPossibleMove()
        {
            bool[,] matrix = PossibleMoves();

            for (int i = 0; i < chessboard.lines; i++)
            {
                for (int j = 0; j < chessboard.columns; j++)
                {
                    if (matrix[i, j])
                        return true;
                }
            }

            return false;
        }

        public bool CanMoveFor(Position position)
        {
            return PossibleMoves()[position.line, position.column];
        }


        public abstract bool[,] PossibleMoves();

    }
}
