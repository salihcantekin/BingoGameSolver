namespace Bingo.Console.Models
{
    public class BoardCell
    {
        public int Value { get; set; }

        public bool IsMarked { get; set; }

        public int ColumnIndex { get; set; }

        public int RowIndex { get; set; }
    }

}
