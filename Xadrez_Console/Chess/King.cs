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
    }
}
