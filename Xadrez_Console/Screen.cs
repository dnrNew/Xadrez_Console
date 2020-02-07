using System;
using System.Collections.Generic;
using System.Text;
using ChessBoard;

namespace Xadrez_Console
{
    class Screen
    {

        public  static void showChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.lines; i++)
            {
                for (int j = 0; j < chessboard.columns; j++)
                {
                    if (chessboard.piece(i, j) == null)
                        Console.Write("- ");
                    else
                        Console.Write(chessboard.piece(i, j)  + " ");
                }
                Console.WriteLine();
            }

        }

    }
}
