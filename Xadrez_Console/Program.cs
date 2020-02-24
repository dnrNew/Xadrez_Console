using Board;
using Chess;
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
                GameChess gameChess = new GameChess();

                while (!gameChess.finished)
                {
                    Console.Clear();
                    Screen.ShowChessboard(gameChess.chessboard);

                    Console.WriteLine();
                    Console.Write("Origin: ");
                    Position origin = Screen.ReadPositionChess().ToPosition();
                    Console.Write("Destiny: ");
                    Position destiny = Screen.ReadPositionChess().ToPosition();

                    gameChess.playMove(origin, destiny);

                }

            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }

            Console.ReadKey();
        }
    }
}
