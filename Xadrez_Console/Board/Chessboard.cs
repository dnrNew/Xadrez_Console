namespace Board
{
    class Chessboard
    {
        public int lines { get; set; }
        public int columns { get; set; }
        private Piece[,] pieces;

        public Chessboard(int lines, int columns)
        {
            this.lines = lines;
            this.columns = columns;
            pieces = new Piece[lines, columns];
        }
        
        public bool PieceExist(Position position)
        {
            ValidationPosition(position);
            return Piece(position) != null;
        }

        public Piece Piece(int line, int column)
        {
            return pieces[line, column];
        }

        public Piece Piece(Position position)
        {
            return pieces[position.line, position.column];
        }

        public void InsertPiece(Piece piece, Position position)
        {
            if (PieceExist(position))
                throw new BoardException("Exist piece in position selected!");

            pieces[position.line, position.column] = piece;
            piece.position = position;
        }

        public bool PositionValidated(Position position)
        {
            if (position.line < 0 || position.line >= lines || position.column < 0 || position.column >= columns)
                return false;

            return true;
        }

        public void ValidationPosition(Position position)
        {
            if (!PositionValidated(position))
                throw new BoardException("Position Invalidate!");
        }

    }
}
