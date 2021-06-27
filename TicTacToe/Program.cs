using System;

namespace TicTacToe
{
    class Program
    {
        static void Main(string[] args)
        {
            Board board = new Board();
            board.setup();

            while (true)
            {
                Console.WriteLine("Player " + board.currentPlayer + " choose a pos (1-9): ");

                int pos = Convert.ToInt16(Console.ReadLine());
                board.place(pos);
                if (board.isWin()) board.reset();
            }
        }
    }
}
