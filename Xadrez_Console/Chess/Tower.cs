using Board;

namespace XadrezConsole.Chess
{
    class Tower : Piece
    {
        public Tower(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "T";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[chessboard.lines, chessboard.columns];

            Position matrixPosition = new Position(0, 0);

            //Up
            matrixPosition.SetValues(position.line - 1, position.column);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.line = matrixPosition.line - 1;
            }

            //Down
            matrixPosition.SetValues(position.line + 1, position.column);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.line = matrixPosition.line + 1;
            }

            //Right
            matrixPosition.SetValues(position.line, position.column + 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.column = matrixPosition.column + 1;
            }

            //Left
            matrixPosition.SetValues(position.line, position.column - 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.column = matrixPosition.column - 1;
            }

            return matrix;
        }

        private bool CanMove(Position position)
        {
            Piece piece = chessboard.Piece(position);
            return piece == null || piece.color != color;
        }
    }
}