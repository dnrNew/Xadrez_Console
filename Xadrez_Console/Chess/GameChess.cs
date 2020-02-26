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
        private HashSet<Piece> pieces;
        private HashSet<Piece> piecesCaptured;
        public bool check { get; private set; }

        public GameChess()
        {
            chessboard = new Chessboard(8, 8);
            turn = 1;
            playCurrent = Color.White;
            finished = false;
            pieces = new HashSet<Piece>();
            piecesCaptured = new HashSet<Piece>();
            InsertPieces();
            check = false;
        }

        public Piece PlayMove(Position origin, Position destiny)
        {
            Piece piece = chessboard.RemovePiece(origin);
            piece.AddMovesQuantity();
            Piece pieceCapture = chessboard.RemovePiece(destiny);
            chessboard.InsertPiece(piece, destiny);

            if (pieceCapture != null)
                piecesCaptured.Add(pieceCapture);

            return pieceCapture;
        }

        public void ReturnMove(Position origin, Position destiny, Piece pieceCapture)
        {
            Piece piece = chessboard.RemovePiece(destiny);
            piece.DeleteMovesQuantity();

            if (pieceCapture != null)
            {
                chessboard.InsertPiece(pieceCapture, destiny);
                piecesCaptured.Remove(pieceCapture);
            }

            chessboard.InsertPiece(piece, origin);
        }

        public void PerformMove(Position origin, Position destiny)
        {
            Piece pieceCaptured = PlayMove(origin, destiny);

            if (IsCheck(playCurrent))
            {
                ReturnMove(origin, destiny, pieceCaptured);
                throw new BoardException("It is not allowed to put in check!");
            }

            if (IsCheck(OpponentColor(playCurrent)))
                check = true;
            else
                check = false;

            if (IsCheckMate(OpponentColor(playCurrent)))
                finished = true;
            else
            {
                turn++;
                ChangePlayer();
            }
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

        public void ValidateDestinyPosition(Position origin, Position destiny)
        {
            if (!chessboard.Piece(origin).IsPossibleMove(destiny))
                throw new BoardException("Destiny position invalid!");
        }

        private void ChangePlayer()
        {
            if (playCurrent == Color.White)
                playCurrent = Color.Black;
            else
                playCurrent = Color.White;
        }

        public HashSet<Piece> PiecesCaptured(Color color)
        {
            HashSet<Piece> pieces = new HashSet<Piece>();

            foreach (Piece piece in piecesCaptured)
            {
                if (piece.color == color)
                    pieces.Add(piece);
            }

            return pieces;
        }

        public HashSet<Piece> PiecesInGame(Color color)
        {
            HashSet<Piece> piecesGame = new HashSet<Piece>();

            foreach (Piece piece in pieces)
            {
                if (piece.color == color)
                    piecesGame.Add(piece);
            }

            piecesGame.ExceptWith(PiecesCaptured(color));
            return piecesGame;
        }

        private Color OpponentColor(Color color)
        {
            if (color == Color.White)
                return Color.Black;
            else
                return Color.White;
        }

        private Piece KingSelect(Color color)
        {
            foreach (Piece piece in PiecesInGame(color))
            {
                if (piece is King)
                    return piece;
            }

            return null;
        }

        public bool IsCheck(Color color)
        {
            Piece king = KingSelect(color);

            if (king == null)
                throw new BoardException("Don't have king of " + color + " color in chessboard!");

            foreach (Piece piece in PiecesInGame(OpponentColor(color)))
            {
                bool[,] matrix = piece.PossibleMoves();

                if (matrix[king.position.line, king.position.column])
                    return true;
            }

            return false;
        }

        public bool IsCheckMate(Color color)
        {
            if (!IsCheck(color))
                return false;

            foreach (Piece piece in PiecesInGame(color))
            {
                bool[,] matrix = piece.PossibleMoves();

                for (int i = 0; i < chessboard.lines; i++)
                {
                    for (int j = 0; j < chessboard.columns; j++)
                    {
                        if (matrix[i, j])
                        {
                            Position origin = piece.position;
                            Position destiny = new Position(i, j);
                            Piece pieceCapture = PlayMove(origin, destiny);
                            bool isCheck = IsCheck(color);
                            ReturnMove(origin, destiny, pieceCapture);

                            if (!isCheck)
                                return false;
                        }
                    }
                }
            }

            return true;
        }

        public void InsertNewPiece(char column, int line, Piece piece)
        {
            chessboard.InsertPiece(piece, new PositionChess(column, line).ToPosition());
            pieces.Add(piece);
        }

        private void InsertPieces()
        {
            InsertNewPiece('a', 1, new Tower(chessboard, Color.White));
            InsertNewPiece('b', 1, new Horse(chessboard, Color.White));
            InsertNewPiece('c', 1, new Bishop(chessboard, Color.White));
            InsertNewPiece('d', 1, new Queen(chessboard, Color.White));
            InsertNewPiece('e', 1, new King(chessboard, Color.White));
            InsertNewPiece('f', 1, new Bishop(chessboard, Color.White));
            InsertNewPiece('g', 1, new Horse(chessboard, Color.White));
            InsertNewPiece('h', 1, new Tower(chessboard, Color.White));
            InsertNewPiece('a', 2, new Pawn(chessboard, Color.White));
            InsertNewPiece('b', 2, new Pawn(chessboard, Color.White));
            InsertNewPiece('c', 2, new Pawn(chessboard, Color.White));
            InsertNewPiece('d', 2, new Pawn(chessboard, Color.White));
            InsertNewPiece('e', 2, new Pawn(chessboard, Color.White));
            InsertNewPiece('f', 2, new Pawn(chessboard, Color.White));
            InsertNewPiece('g', 2, new Pawn(chessboard, Color.White));
            InsertNewPiece('h', 2, new Pawn(chessboard, Color.White));

            InsertNewPiece('a', 8, new Tower(chessboard, Color.Black));
            InsertNewPiece('b', 8, new Horse(chessboard, Color.Black));
            InsertNewPiece('c', 8, new Bishop(chessboard, Color.Black));
            InsertNewPiece('d', 8, new Queen(chessboard, Color.Black));
            InsertNewPiece('e', 8, new King(chessboard, Color.Black));
            InsertNewPiece('f', 8, new Bishop(chessboard, Color.Black));
            InsertNewPiece('g', 8, new Horse(chessboard, Color.Black));
            InsertNewPiece('h', 8, new Tower(chessboard, Color.Black));
            InsertNewPiece('a', 7, new Pawn(chessboard, Color.Black));
            InsertNewPiece('b', 7, new Pawn(chessboard, Color.Black));
            InsertNewPiece('c', 7, new Pawn(chessboard, Color.Black));
            InsertNewPiece('d', 7, new Pawn(chessboard, Color.Black));
            InsertNewPiece('e', 7, new Pawn(chessboard, Color.Black));
            InsertNewPiece('f', 7, new Pawn(chessboard, Color.Black));
            InsertNewPiece('g', 7, new Pawn(chessboard, Color.Black));
            InsertNewPiece('h', 7, new Pawn(chessboard, Color.Black));
        }

    }
}
