using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Bingo.Console.Models
{
    public class BingoBoard
    {
        public event EventHandler<BingoBoard> OnBingoCompleted;

        public BingoBoard()
        {
            Rows = new List<BoardRow>();
            Columns = new List<BoardColumn>();
        }

        private int counter = 0;
        private int lastMarkedNumber = 0;
        private bool bingoCompleted;
        private bool rowsCompleted;
        private bool columnsCompleted;



        public bool BingoCompleted => bingoCompleted;
        public int BoardRowNumberCount { get; set; } = 5;
        public int BoardColumnNumberCount { get; set; } = 5;

        public List<BoardRow> Rows { get; private set; }
        public List<BoardColumn> Columns { get; private set; }

        private void AddNumberToBoard(int number)
        {
            var indexes = GetIndexesByCounter();

            var row = GetRowByCounter(indexes.RowIndex);

            if (row == null)
            {
                row = new BoardRow(indexes.RowIndex);
                row.Add(number);

                Rows.Add(row);
            }
            else
                row.SetValue(indexes.ColumnIndex, number);

            var column = GetColumnByCounter(indexes.ColumnIndex);

            if (column == null)
            {
                column = new BoardColumn(indexes.ColumnIndex);
                column.Add(number);

                Columns.Add(column);
            }
            else
                column.SetValue(indexes.RowIndex, number);

            counter++;
        }


        public BingoBoard SetNumbers(params int[] numbers)
        {
            foreach (var item in numbers)
            {
                AddNumberToBoard(item);
            }

            return this;
        }

        public BingoBoard SetNumbers(IEnumerable<int> numbers)
        {
            foreach (var item in numbers)
            {
                AddNumberToBoard(item);
            }

            return this;
        }

        public int CalculateScore()
        {
            int unMarkedSum = 0;

            if (rowsCompleted)
                unMarkedSum = Rows.SelectMany(i => i.Cells).Where(i => !i.IsMarked).Sum(i => i.Value);
            else
                unMarkedSum = Columns.SelectMany(i => i.Cells).Where(i => !i.IsMarked).Sum(i => i.Value);

            return unMarkedSum * lastMarkedNumber;
        }

        public void CheckAndMarkNumber(int number)
        {
            var rowCells = Rows.SelectMany(i => i.Cells);

            var foundCell = rowCells.FirstOrDefault(i => i.Value == number);
            if (foundCell != null)
            {
                foundCell.IsMarked = true;
                lastMarkedNumber = foundCell.Value;

                Columns[foundCell.ColumnIndex].Cells.FirstOrDefault(i => i.Value == foundCell.Value).IsMarked = true;
            }

            rowsCompleted = Rows.Any(i => i.Cells.All(j => j.IsMarked));
            columnsCompleted = Columns.Any(i => i.Cells.All(j => j.IsMarked));

            if (rowsCompleted || columnsCompleted)
            {
                OnBingoCompleted?.Invoke(this, this);
                bingoCompleted = true;
            }
        }

        private (int RowIndex, int ColumnIndex) GetIndexesByCounter()
        {
            int r = (counter / BoardRowNumberCount);
            int c = (counter % BoardColumnNumberCount);

            r = Math.Max(r, 0);
            c = Math.Max(c, 0);

            return (r, c);
        }


        private BoardRow GetRowByCounter(int rowIndex)
        {
            if (rowIndex > -1 && rowIndex < Rows.Count)
            {
                return Rows[rowIndex];
            }

            return null;
        }

        private BoardColumn GetColumnByCounter(int colIndex)
        {
            if (colIndex > -1 && colIndex < Columns.Count)
            {
                return Columns[colIndex];
            }

            return null;
        }




        public void Print()
        {
            for (int i = 0; i < Rows.Count; i++)
            {
                for (int j = 0; j < Rows[i].Cells.Count; j++)
                {
                    var cell = Rows[i].Cells[j];

                    if (cell.IsMarked)
                    {
                        System.Console.ForegroundColor = ConsoleColor.Yellow;
                        System.Console.Write($"{cell.Value,2} ");
                    }
                    else
                    {
                        System.Console.ResetColor();
                        System.Console.Write($"{cell.Value,2} ");
                    }
                }

                System.Console.WriteLine();

            }
        }
    }

}
