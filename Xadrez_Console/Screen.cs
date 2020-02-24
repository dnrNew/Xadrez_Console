using Board;
using System;
using XadrezConsole.Chess;

namespace XadrezConsole
{
    class Screen
    {
        public static void ShowChessboard(Chessboard chessboard)
        {
            for (int i = 0; i < chessboard.lines; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < chessboard.columns; j++)
                {
                    if (chessboard.Piece(i, j) == null)
                        Console.Write("- ");
                    else
                    {
                        ShowPiece(chessboard.Piece(i, j));
                        Console.Write(" ");
                    }

                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

        }

        public static PositionChess ReadPositionChess()
        {
            string keyPressPosition = Console.ReadLine();
            char column = keyPressPosition[0];
            int line = int.Parse(keyPressPosition[1] + "");
            return new PositionChess(column, line);
        }

        public static void ShowPiece(Piece piece)
        {
            if (piece.color == Color.White)
                Console.Write(piece);
            else
            {
                ConsoleColor defaultColor = Console.ForegroundColor;
                Console.ForegroundColor = ConsoleColor.Yellow;
                Console.Write(piece);
                Console.ForegroundColor = defaultColor;
            }
        }

    }
}
