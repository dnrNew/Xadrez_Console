using Board;

namespace XadrezConsole.Chess
{
    class Bishop : Piece
    {
        public Bishop(Chessboard chessboard, Color color) : base(chessboard, color)
        {
        }

        public override string ToString()
        {
            return "B";
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[chessboard.lines, chessboard.columns];

            Position matrixPosition = new Position(0, 0);

            //NO
            matrixPosition.SetValues(position.line - 1, position.column - 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(matrixPosition.line - 1, matrixPosition.column - 1);
            }

            //NE
            matrixPosition.SetValues(position.line - 1, position.column + 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(matrixPosition.line - 1, matrixPosition.column + 1);
            }

            //SE
            matrixPosition.SetValues(position.line + 1, position.column + 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(matrixPosition.line + 1, matrixPosition.column + 1);
            }

            //SO
            matrixPosition.SetValues(position.line + 1, position.column - 1);

            while (chessboard.PositionValidated(matrixPosition) && CanMove(matrixPosition))
            {
                matrix[matrixPosition.line, matrixPosition.column] = true;

                if (chessboard.Piece(matrixPosition) != null && chessboard.Piece(matrixPosition).color != color)
                    break;

                matrixPosition.SetValues(matrixPosition.line + 1, matrixPosition.column - 1);
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