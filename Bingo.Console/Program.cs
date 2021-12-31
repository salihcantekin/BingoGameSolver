using Bingo.Console.Models;
using System;

namespace Bingo.Console
{
    internal class Program
    {
        private static Game game = new Game();

        static void Main(string[] args)
        {
            game = new Game();
            game.SetNumbers(new[] { 7, 4, 9, 5, 11, 17, 23, 2, 0, 14, 21, 24, 10, 16, 13, 6, 15, 25, 12, 22, 18, 20, 8, 19, 3, 26, 1 });

            GenerateBoard1();
            GenerateBoard2();
            GenerateBoard3();

            int nextNumber;

            do
            {
                nextNumber = game.GetNextNumber();

                game.FindNumberOnBoards(nextNumber);

                bool anyBingo = game.AnyBingo();

                if (anyBingo)
                {
                    System.Console.WriteLine("Bingooooo");
                    var bingoBoard = game.GetCompletedBoard();

                    var score = bingoBoard.CalculateScore();


                    bingoBoard.Print();

                    System.Console.WriteLine($"\nScore: {score}");

                    break;
                }

            } while (nextNumber != -1);

            System.Console.ReadLine();
        }


        private static void GenerateBoard1()
        {
            var board = new BingoBoard();

            board.SetNumbers(22, 13, 17, 11, 0, 8, 2, 23, 4, 24, 21, 9, 14, 16, 7, 6, 10, 3, 18, 5, 1, 12, 20, 15, 19);

            game.AddBoard(board);
        }

        private static void GenerateBoard2()
        {
            var board = new BingoBoard();

            board.SetNumbers(3, 15, 0, 2, 22, 9, 18, 13, 17, 5, 19, 8, 7, 25, 23, 20, 11, 10, 24, 4, 14, 21, 16, 12, 6);

            game.AddBoard(board);
        }

        private static void GenerateBoard3()
        {
            var board = new BingoBoard();

            board.SetNumbers(14, 21, 17, 24, 4, 10, 16, 15, 9, 19, 18, 8, 23, 26, 20, 22, 11, 13, 6, 5, 2, 0, 12, 3, 7);

            game.AddBoard(board);
        }
    }
}
