using System;
using System.Collections.Generic;
using System.Text;

namespace ChessBoard
{
    class Piece
    {
        public Position position { get; set; }
        public Color color { get; protected set; }
        public int moveQty { get; protected set; }
        public Chessboard chessboard{ get; protected set; }

        public Piece(Position position, Color color, Chessboard chessboard)
        {
            this.position = position;
            this.color = color;
            this.chessboard = chessboard;
            this.moveQty = 0;
        }
    }       
}
