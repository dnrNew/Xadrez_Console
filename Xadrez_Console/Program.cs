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
                        Screen.ShowChessboard(gameChess.chessboard);
                        Console.WriteLine();
                        Console.WriteLine("Turn: " + gameChess.turn);
                        Console.WriteLine("Waiting played: " + gameChess.playCurrent);

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

                        gameChess.PerformMove(origin, destiny);

                    }
                    catch (BoardException ex)
                    {
                        Console.WriteLine();
                        Console.WriteLine(ex.Message);
                        Console.Write("Try again: ");
                        Console.ReadLine();
                    }
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
