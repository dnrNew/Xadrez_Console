using Board;

namespace Chess
{
    class Horse : Piece
    {
        public Horse(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "H";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[chessboard.lines, chessboard.columns];

            Position matrixPosition = new Position(0, 0);

            matrixPosition.SetValues(position.line - 1, position.column - 2);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            matrixPosition.SetValues(position.line - 2, position.column - 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            matrixPosition.SetValues(position.line - 2, position.column + 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            matrixPosition.SetValues(position.line - 1, position.column + 2);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            matrixPosition.SetValues(position.line + 1, position.column + 2);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            matrixPosition.SetValues(position.line + 2, position.column + 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            matrixPosition.SetValues(position.line + 2, position.column - 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            matrixPosition.SetValues(position.line + 1, position.column - 2);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            return matrix;
        }

        private bool CanMove(Position position)
        {
            Piece piece = chessboard.Piece(position);
            return piece == null || piece.color != color;
        }
    }
}