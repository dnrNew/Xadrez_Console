using System;
using System.Collections.Generic;
using System.Text;
using Board;
using XadrezConsole.Chess;

namespace Chess
{
    class GameChess
    {
        public Chessboard chessboard { get; private set; }
        private int turn;
        private Color playCurrent;
        public bool finished { get; private set; }
        
        public GameChess()
        {
            chessboard = new Chessboard(8, 8);
            turn = 1;
            playCurrent = Color.White;
            InsertPieces();
            finished = false;
        }

        public void playMove (Position origin, Position destiny)
        {
            Piece piece = chessboard.RemovePiece(origin);
            piece.AddMovesQuantity();
            Piece pieceCapture = chessboard.RemovePiece(destiny);
            chessboard.InsertPiece(piece, destiny);
        }

        private void InsertPieces()
        {
            chessboard.InsertPiece(new Tower(chessboard, Color.White), new PositionChess('c', 1).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.White), new PositionChess('c', 2).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.White), new PositionChess('d', 2).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.White), new PositionChess('e', 2).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.White), new PositionChess('e', 1).ToPosition());
            chessboard.InsertPiece(new King(chessboard, Color.White), new PositionChess('d', 1).ToPosition());

            chessboard.InsertPiece(new Tower(chessboard, Color.Black), new PositionChess('c', 7).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.Black), new PositionChess('c', 8).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.Black), new PositionChess('d', 7).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.Black), new PositionChess('e', 7).ToPosition());
            chessboard.InsertPiece(new Tower(chessboard, Color.Black), new PositionChess('e', 8).ToPosition());
            chessboard.InsertPiece(new King(chessboard, Color.Black), new PositionChess('d', 8).ToPosition());
        }

    }
}
