using Board;
using Chess;

namespace XadrezConsole.Chess
{
    class Pawn : Piece
    {
        private GameChess game;

        public Pawn(Chessboard chessboard, Color color, GameChess game) : base(chessboard, color)
        {
            this.game = game;
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

                if (chessboard.PositionValidated(matrixPosition) && FreePosition(matrixPosition) && movesQuantity == 0)
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line - 1, position.column - 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line - 1, position.column + 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                //Special play En Passant
                if (position.line == 3)
                {
                    Position left = new Position(position.line, position.column - 1);

                    if (chessboard.PositionValidated(left) && ExistOpponent(left) && chessboard.Piece(left) == game.vulnerableEnPassant)
                        matrix[left.line, left.column] = true;

                    Position right = new Position(position.line, position.column + 1);

                    if (chessboard.PositionValidated(right) && ExistOpponent(right) && chessboard.Piece(right) == game.vulnerableEnPassant)
                        matrix[right.line, right.column] = true;
                }
            }
            else
            {
                matrixPosition.SetValues(position.line + 1, position.column);

                if (chessboard.PositionValidated(matrixPosition) && FreePosition(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line + 2, position.column);

                if (chessboard.PositionValidated(matrixPosition) && FreePosition(matrixPosition) && movesQuantity == 0)
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line + 1, position.column - 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                matrixPosition.SetValues(position.line + 1, position.column + 1);

                if (chessboard.PositionValidated(matrixPosition) && ExistOpponent(matrixPosition))
                    matrix[matrixPosition.line, matrixPosition.column] = true;

                //Special play En Passant
                if (position.line == 4)
                {
                    Position left = new Position(position.line, position.column - 1);

                    if (chessboard.PositionValidated(left) && ExistOpponent(left) && chessboard.Piece(left) == game.vulnerableEnPassant)
                        matrix[left.line, left.column] = true;

                    Position right = new Position(position.line, position.column + 1);

                    if (chessboard.PositionValidated(right) && ExistOpponent(right) && chessboard.Piece(right) == game.vulnerableEnPassant)
                        matrix[right.line, right.column] = true;
                }
            }

            return matrix;
        }

    }
}
