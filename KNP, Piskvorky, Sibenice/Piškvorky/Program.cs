using System;

namespace Piškvorky
{
    internal class Program
    {
        static void Main(string[] args)
        {
            string userSymbol = "";
            string compSymbol = "";
            string[] board = { " ", " ", " ", " ", " ", " ", " ", " ", " " };

            // Symbol selection
            while (userSymbol != "X" && userSymbol != "O")
            {
                Console.Write("Vyberte si znak (X/O): ");
                userSymbol = Console.ReadLine().ToUpper();
                if (userSymbol != "X" && userSymbol != "O")
                {
                    Console.WriteLine("Neplatný výběr. Zkuste to znovu.");
                }
            }
            compSymbol = userSymbol == "X" ? "O" : "X";

            int turn = 0;
            bool userTurn = true;
            string winner = null;

            while (winner == null && turn < 9)
            {
                PrintBoard(board);

                if (userTurn)
                {
                    int move = GetUserMove(board);
                    board[move] = userSymbol;
                }
                else
                {
                    int move = GetComputerMove(board);
                    board[move] = compSymbol;
                    Console.WriteLine($"Počítač zvolil pozici {move + 1}");
                }

                winner = CheckWinner(board, userSymbol, compSymbol);
                userTurn = !userTurn;
                turn++;
            }

            PrintBoard(board);
            if (winner == userSymbol)
                Console.WriteLine("Gratulujeme! Vyhráli jste!");
            else if (winner == compSymbol)
                Console.WriteLine("Počítač vyhrál!");
            else
                Console.WriteLine("Remíza!");
        }

        static void PrintBoard(string[] board)
        {
            Console.WriteLine();
            Console.WriteLine($" {board[0]} | {board[1]} | {board[2]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[3]} | {board[4]} | {board[5]} ");
            Console.WriteLine("---+---+---");
            Console.WriteLine($" {board[6]} | {board[7]} | {board[8]} ");
            Console.WriteLine();
        }

        static int GetUserMove(string[] board)
        {
            int move = -1;
            while (move < 0 || move > 8 || board[move] != " ")
            {
                Console.Write("Zadejte číslo pozice (1-9): ");
                string input = Console.ReadLine();
                if (int.TryParse(input, out int pos) && pos >= 1 && pos <= 9)
                {
                    move = pos - 1;
                    if (board[move] != " ")
                    {
                        Console.WriteLine("Pozice je již obsazena. Zkuste jinou.");
                        move = -1;
                    }
                }
                else
                {
                    Console.WriteLine("Neplatný vstup. Zadejte číslo od 1 do 9.");
                }
            }
            return move;
        }

        static int GetComputerMove(string[] board)
        {
            Random rnd = new Random();
            int move;
            do
            {
                move = rnd.Next(0, 9);
            } while (board[move] != " ");
            return move;
        }

        static string CheckWinner(string[] board, string userSymbol, string compSymbol)
        {
            int[][] winPatterns = new int[][]
            {
                new int[]{0,1,2}, new int[]{3,4,5}, new int[]{6,7,8}, // rows
                new int[]{0,3,6}, new int[]{1,4,7}, new int[]{2,5,8}, // columns
                new int[]{0,4,8}, new int[]{2,4,6} // diagonals
            };

            foreach (var pattern in winPatterns)
            {
                if (board[pattern[0]] != " " &&
                    board[pattern[0]] == board[pattern[1]] &&
                    board[pattern[1]] == board[pattern[2]])
                {
                    return board[pattern[0]];
                }
            }
            return null;
        }
    }
}
