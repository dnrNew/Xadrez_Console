using Board;
using System;

namespace XadrezConsole
{
    class Screen
    {
        public static void ShowChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.lines; i++)
            {
                for (int j = 0; j < chessboard.columns; j++)
                {
                    if (chessboard.Piece(i, j) == null)
                        Console.Write("- ");
                    else
                        Console.Write(chessboard.Piece(i, j) + " ");
                }
                Console.WriteLine();
            }

        }

    }
}
