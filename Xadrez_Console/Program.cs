using Board;
using System;
using XadrezConsole.Chess;

namespace XadrezConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            try
            {
                Chessboard chessboard = new Chessboard(8, 8);

                chessboard.InsertPiece(new Tower(chessboard, Color.Black), new Position(0, 0));
                chessboard.InsertPiece(new Tower(chessboard, Color.Black), new Position(1, 3));
                chessboard.InsertPiece(new King(chessboard, Color.Black), new Position(2, 4));

                Screen.ShowChessboard(chessboard);
                
            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
