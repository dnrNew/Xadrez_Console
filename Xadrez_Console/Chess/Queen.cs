using Board;

namespace XadrezConsole.Chess
{
    class Queen : Piece
    {
        public Queen(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "Q";
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

                matrixPosition.SetValues(position.line - 1, position.column);
            }

            //Down
            matrixPosition.SetValues(position.line + 1, position.column);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(position.line + 1, position.column);
            }

            //Right
            matrixPosition.SetValues(position.line, position.column + 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(position.line, position.column + 1);
            }

            //Left
            matrixPosition.SetValues(position.line, position.column - 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(position.line, position.column -1);
            }

            //NO
            matrixPosition.SetValues(position.line - 1, position.column - 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(position.line - 1, position.column - 1);
            }

            //NE
            matrixPosition.SetValues(position.line - 1, position.column + 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(position.line - 1, position.column + 1);
            }

            //SE
            matrixPosition.SetValues(position.line + 1, position.column + 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(position.line + 1, position.column + 1);
            }

            //SO
            matrixPosition.SetValues(position.line + 1, position.column - 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(position.line + 1, position.column - 1);
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