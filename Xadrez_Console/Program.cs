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
                    try
                    {
                        Console.Clear();
                        Screen.ShowGame(gameChess);

                        Console.WriteLine();
                        Console.Write("Origin: ");
                        Position origin = Screen.ReadPositionChess().ToPosition();
                        gameChess.ValidateOriginPosition(origin);

                        bool[,] possiblePositions = gameChess.chessboard.Piece(origin).PossibleMoves();

                        Console.Clear();
                        Screen.ShowChessboard(gameChess.chessboard, possiblePositions);

                        Console.WriteLine();
                        Console.Write("Destiny: ");
                        Position destiny = Screen.ReadPositionChess().ToPosition();
                        gameChess.ValidateDestinyPosition(origin, destiny);

                        gameChess.PerformMove(origin, destiny);

                    }
                    catch (BoardException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                        Console.ReadLine();
                    }
                }

                Console.Clear();
                Screen.ShowGame(gameChess);

            }
            catch (BoardException ex)
            {
                Console.WriteLine(ex.Message);
            }


            Console.ReadKey();
        }
    }
}
