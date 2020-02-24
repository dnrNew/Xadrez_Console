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
                    ShowPiece(chessboard.Piece(i, j));

                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");

        }

        public static void ShowChessboard(Chessboard chessboard, bool[,] possiblePositions)
        {
            ConsoleColor initBackground = Console.BackgroundColor;
            ConsoleColor changeBackground = ConsoleColor.DarkGray;

            for (int i = 0; i < chessboard.lines; i++)
            {
                Console.Write(8 - i + " ");

                for (int j = 0; j < chessboard.columns; j++)
                {
                    if (possiblePositions[i, j])
                        Console.BackgroundColor = changeBackground;
                    else
                        Console.BackgroundColor = initBackground;

                    ShowPiece(chessboard.Piece(i, j));
                    Console.BackgroundColor = initBackground;
                }
                Console.WriteLine();
            }
            Console.WriteLine("  A B C D E F G H");
            Console.BackgroundColor = initBackground;
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
            if (piece == null)
                Console.Write("- ");
            else
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
                Console.Write(" ");
            }
        }

    }
}
