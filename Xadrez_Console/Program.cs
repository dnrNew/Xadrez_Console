using ChessBoard;
using System;

namespace Xadrez_Console
{
    class Program
    {
        static void Main(string[] args)
        {
            Position P = new Position(3, 4);

            Console.WriteLine(P);

            Console.ReadKey();
        }
    }
}
