using ChessBoard;
using System;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Chessboard chessboard = new Chessboard(8, 8);

            Screen.showChessboard(chessboard);


            Console.ReadKey();
        }
    }
}
