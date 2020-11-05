using Board;
using Chess;

namespace XadrezConsole.Chess
{
    class King : Piece
    {
        private GameChess game;

        public King(Chessboard chessboard, Color color, GameChess game) : base(chessboard, color)
        {
            this.game = game;
        }

        public override string ToString()
        {
            return "K";
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

            //Special play Castle
            if (movesQuantity == 0 && !game.check)
            {
                //Special play small Castle
                Position positionRook = new Position(position.line, position.column + 3);

                if (RookCanCastle(positionRook))
                {
                    Position position1 = new Position(position.line, position.column + 1);
                    Position position2 = new Position(position.line, position.column + 2);

                    if (chessboard.Piece(position1) == null && chessboard.Piece(position2) == null)
                        matrix[position.line, position.column + 2] = true;
                }

                //Special play big Castle
                Position positionBigRook = new Position(position.line, position.column - 4);

                if (RookCanCastle(positionBigRook))
                {
                    Position position1 = new Position(position.line, position.column - 1);
                    Position position2 = new Position(position.line, position.column - 2);
                    Position position3 = new Position(position.line, position.column - 3);

                    if (chessboard.Piece(position1) == null && chessboard.Piece(position2) == null && chessboard.Piece(position3) == null)
                        matrix[position.line, position.column - 2] = true;
                }
            }


            return matrix;
        }

        private bool RookCanCastle(Position position)
        {
            Piece piece = chessboard.Piece(position);
            return piece != null && piece is Rook && piece.color == color && piece.movesQuantity == 0;
        }

        private bool CanMove(Position position)
        {
            Piece piece = chessboard.Piece(position);
            return piece == null || piece.color != color;
        }
    }
}
