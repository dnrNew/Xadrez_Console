namespace Board
{
    class Piece
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
    }
}
