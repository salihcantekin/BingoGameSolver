using System.Collections.Generic;
using System.Linq;

namespace Bingo.Console.Models
{
    public abstract class BoardBase
    {
        public BoardBase(int index)
        {
            Index = index;
            Cells = new List<BoardCell>();
        }

        public int Index { get; init; }

        public List<BoardCell> Cells { get; private set; }

        

        public bool FindAndMarkedNumber(int number)
        {
            var foundCell = Cells.FirstOrDefault(i => i.Value == number);

            if(foundCell != null)
                foundCell.IsMarked = true;

            return foundCell != null;
        }
    }

}
