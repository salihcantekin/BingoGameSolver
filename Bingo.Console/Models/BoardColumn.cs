using System.Collections.Generic;

namespace Bingo.Console.Models
{
    public class BoardColumn : BoardBase
    {
        public BoardColumn(int columnIndex) : base(columnIndex) { }

        public void SetValue(int rowIndex, int number)
        {
            if (rowIndex < Cells.Count)
                Cells[rowIndex].Value = number;
            else
                Add(number, false);
        }

        public void Add(int number, bool isMarked = false)
        {
            Cells.Add(new BoardCell()
            {
                IsMarked = isMarked,
                Value = number,
                RowIndex = Cells.Count,
                ColumnIndex = Index
            });
        }
    }

}
