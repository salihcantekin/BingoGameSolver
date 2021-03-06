using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Console.Models
{
    public class Game
    {
        private List<int> numberList = new List<int>();
        public IReadOnlyList<int> Numbers => numberList.AsReadOnly();

        public List<BingoBoard> Boards { get; private set; }

        public Game()
        {
            Boards = new List<BingoBoard>();
        }

        public Game AddBoard(BingoBoard board)
        {
            Boards.Add(board);
            return this;
        }

        public void SetNumbers(params int[] numbers)
        {
            numberList.AddRange(numbers);
        }

        public int GetNextNumber()
        {
            if (!numberList.Any())
                return -1;

            var number = numberList.FirstOrDefault();
            numberList.Remove(number);

            return number;
        }

        public void FindNumberOnBoards(int number)
        {
            foreach (var board in Boards)
            {
                board.CheckAndMarkNumber(number);
            }
        }

        public bool AnyBingo()
        {
            return Boards.Any(i => i.BingoCompleted);
        }

        public BingoBoard GetCompletedBoard()
        {
            return Boards.FirstOrDefault(i => i.BingoCompleted);
        }
    }
}
