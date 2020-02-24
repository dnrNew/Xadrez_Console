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
        public int turn { get; private set; }
        public Color playCurrent { get; private set; }
        public bool finished { get; private set; }

        public GameChess()
        {
            chessboard = new Chessboard(8, 8);
            turn = 1;
            playCurrent = Color.White;
            InsertPieces();
            finished = false;
        }

        public void PlayMove(Position origin, Position destiny)
        {
            Piece piece = chessboard.RemovePiece(origin);
            piece.AddMovesQuantity();
            Piece pieceCapture = chessboard.RemovePiece(destiny);
            chessboard.InsertPiece(piece, destiny);
        }

        public void PerformMove(Position origin, Position destiny)
        {
            PlayMove(origin, destiny);
            turn++;
            ChangePlayer();
        }

        public void ValidateOriginPosition(Position position)
        {
            if (chessboard.Piece(position) == null)
                throw new BoardException("Don't exists piece in origin position selected!");

            if (playCurrent != chessboard.Piece(position).color)
                throw new BoardException("The origin piece chosen is not yours!");

            if (!chessboard.Piece(position).HasPossibleMove())
                throw new BoardException("Don't have possible moves for piece origin selected!");
        }

        private void ChangePlayer()
        {
            if (playCurrent == Color.White)
                playCurrent = Color.Black;
            else
                playCurrent = Color.White;
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
