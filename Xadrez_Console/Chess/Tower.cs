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
    }
}