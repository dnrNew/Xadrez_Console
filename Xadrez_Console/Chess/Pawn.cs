using Board;
using Chess;

namespace XadrezConsole.Chess
{
    class Pawn : Piece
    {
        private GameChess gameChess;

        public Pawn(Chessboard chessboard, Color color) : base(chessboard, color)
        {           
        }

        public override string ToString()
        {
            return "P";
        }

        private bool ExistOpponent(Position position)
        {
            Piece piece = chessboard.Piece(position);
            return piece != null && piece.color != color;
        }

        private bool FreePosition(Position position)
        {
            return chessboard.Piece(position) == null;
        }

        public override bool[,] PossibleMoves()
        {
            bool[,] matrix = new bool[chessboard.lines, chessboard.columns];

            Position matrixPosition = new Position(0, 0);

            if (color == Color.White)
            {
                matrixPosition.SetValues(position.line - 1, position.column);

                if (chessboard.PositionValidated(matrixPosition) && FreePosition(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line - 2, position.column);
                Position position2 = new Position(position.line - 1, position.column);

                if (chessboard.PositionValidated(position2) && FreePosition(position2) && chessboard.PositionValidated(matrixPosition) && FreePosition(matrixPosition) && movesQuantity == 0)
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line - 1, position.column - 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line - 1, position.column + 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;
            }
            else
            {
                matrixPosition.SetValues(position.line + 1, position.column);

                if (chessboard.PositionValidated(matrixPosition) && FreePosition(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line + 2, position.column);
                Position position2 = new Position(position.line + 1, position.column);

                if (chessboard.PositionValidated(position2) && FreePosition(position2) && chessboard.PositionValidated(matrixPosition) && FreePosition(matrixPosition) && movesQuantity == 0)
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line + 1, position.column - 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line + 1, position.column + 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;
            }

            return matrix;
        }

    }
}
