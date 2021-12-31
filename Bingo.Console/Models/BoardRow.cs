namespace Bingo.Console.Models
{

    public class BoardRow : BoardBase
    {
        public BoardRow(int rowIndex) : base(rowIndex) { }


        public void SetValue(int columnIndex, int number)
        {
            if (columnIndex < Cells.Count)
                Cells[columnIndex].Value = number;
            else
                Add(number, false);
        }

        public void Add(int number, bool isMarked = false)
        {
            Cells.Add(new BoardCell()
            {
                IsMarked = isMarked,
                Value = number,
                RowIndex = Index,
                ColumnIndex = Cells.Count
            });
        }
    }

}
