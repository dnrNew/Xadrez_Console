using Board;

namespace XadrezConsole.Chess
{
    class King : Piece
    {
        public King(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "R";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[chessboard.lines, chessboard.columns];

            Position matrixPosition = new Position(0, 0);

            //Up
            matrixPosition.SetValues(position.line - 1, position.column);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            //NE
            matrixPosition.SetValues(position.line - 1, position.column + 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            //Right
            matrixPosition.SetValues(position.line, position.column + 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            //SE
            matrixPosition.SetValues(position.line + 1, position.column + 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            //Down
            matrixPosition.SetValues(position.line + 1, position.column);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            //SO
            matrixPosition.SetValues(position.line + 1, position.column - 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            //Left
            matrixPosition.SetValues(position.line, position.column - 1);

            if (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
                matrix[matrixPosition.line, matrixPosition.column] = true;

            //NO
            matrixPosition.SetValues(position.line - 1, position.column - 1);

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
