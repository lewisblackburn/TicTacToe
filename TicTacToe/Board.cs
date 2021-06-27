using System;
using System.Collections.Generic;
using System.Threading;

namespace TicTacToe
{
    public class Board
    {
        List<Player> players = new List<Player>();
        Dictionary<int, char> symbol = new Dictionary<int, char>()
        {
            { 0,'_' },
            { 1,'X' },
            { 2, 'O' },
        };


        private const int rows = 3;
        private const int cols = 3;


        public int[,] board = new int[rows, cols];
        public int turns = 0;
        Dictionary<int, int[]> position = new Dictionary<int, int[]>()
        {
            { 1, new int[] {0, 0} },
            { 2, new int[] {0, 1} },
            { 3, new int[] {0, 2} },
            { 4, new int[] {1, 0} },
            { 5, new int[] {1, 1} },
            { 6, new int[] {1, 2} },
            { 7, new int[] {2, 0} },
            { 8, new int[] {2, 1} },
            { 9, new int[] {2, 2} },
        };


        public int currentPlayer = 1;

        public Board()
        {   
        }

        public void setup() {
            while (players.ToArray().Length < 2)
            {
                Player player = new Player();
                players.Add(player);
                player.id = players.ToArray().Length;
            }

            draw();
        }

        public void draw() {
            Console.Clear();

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    Console.Write(symbol[board[i, j]]);
                }
                Console.WriteLine();
            }
        }

        public bool isWin()
        {
            foreach (Player player in players)
            {
                if (
                    board[0, 0] == player.id && board[1, 0] == player.id && board[0, 2] == player.id
                    || board[1, 0] == player.id && board[1, 1] == player.id && board[1, 2] == player.id
                    || board[2, 0] == player.id && board[2, 1] == player.id && board[2, 2] == player.id
                    ) { Console.WriteLine("Player " + player.id + " won horizontally!"); return true; }

                else if (
                    board[0, 0] == player.id && board[1, 0] == player.id && board[2, 0] == player.id
                    || board[0, 1] == player.id && board[1, 1] == player.id && board[2, 1] == player.id
                    || board[0, 2] == player.id && board[1, 2] == player.id && board[2, 2] == player.id
                    ) { Console.WriteLine("Player " + player.id + " won vertically!"); return true; }

                else if (
                    board[0, 0] == player.id && board[1, 1] == player.id && board[2, 2] == player.id
                    || board[0, 2] == player.id && board[1, 1] == player.id && board[2, 1] == player.id
                    ) { Console.WriteLine("Player " + player.id + " won diagonally!"); return true; }
            }

            if (turns == 9)
            {
                Console.WriteLine("Draw!");
                return true;
            }


            return false;
        }

        public bool place(int pos) {
            if (board[position[pos][0], position[pos][1]] != 0) return false;

            board[position[pos][0], position[pos][1]] = currentPlayer;

            switch (currentPlayer)
            {
                case 1:
                    currentPlayer = 2;
                    break;
                default:
                    currentPlayer = 1;
                    break;
            }

            turns++;

            draw();   

            return true;
        }

        public void reset()
        {
            Thread.Sleep(2000);

            for (int i = 0; i < rows; i++)
            {
                for (int j = 0; j < cols; j++)
                {
                    board[i, j] = 0;
               }
            }

            players.Clear();
            setup();
            currentPlayer = 1;
        }
    }
}
