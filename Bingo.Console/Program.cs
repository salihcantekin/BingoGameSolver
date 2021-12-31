using Bingo.Console.Models;
using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;

namespace Bingo.Console
{
    internal class Program
    {
        private static void GetNumbersFromFile()
        {
            var filePath = Path.Combine(AppDomain.CurrentDomain.BaseDirectory, "BoardNumbers.txt");
            var lines = File.ReadAllLines(filePath);

            var numbers = new List<int>();
            foreach (var line in lines)
            {
                if (string.IsNullOrEmpty(line))
                {
                    game.AddBoard(new BingoBoard().SetNumbers(numbers));
                    numbers.Clear();
                }

                var rowNumbers = line.Split(new[] { ' ' }, StringSplitOptions.RemoveEmptyEntries).Select(i => int.Parse(i));
                numbers.AddRange(rowNumbers);
            }
        }


        private static Game game = new Game();

        static void Main(string[] args)
        {
            game = new Game();

            GetNumbersFromFile();

            game.SetNumbers(79, 9, 13, 43, 53, 51, 40, 47, 56, 27, 0, 14, 33, 60, 61, 36, 72, 48, 83, 42, 10, 86, 41, 75, 16, 80, 15, 93, 95, 45, 68, 96, 84, 11, 85, 63, 18, 31, 35, 74, 71, 91, 39, 88, 55, 6, 21, 12, 58, 29, 69, 37, 44, 98, 89, 78, 17, 64, 59, 76, 54, 30, 65, 82, 28, 50, 32, 77, 66, 24, 1, 70, 92, 23, 8, 49, 38, 73, 94, 26, 22, 34, 97, 25, 87, 19, 57, 7, 2, 3, 46, 67, 90, 62, 20, 5, 52, 99, 81, 4);
            
            //GenerateBoard1();
            //GenerateBoard2();
            //GenerateBoard3();
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
