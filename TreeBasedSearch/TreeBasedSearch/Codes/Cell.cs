using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class Cell
    {
        public Cell(int x, int y, Object item = Object.PATH)
        {
            X = x;
            Y = y;
            Item = item;
            IsVisited = false;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Object Item { get; set; }
        public bool IsVisited { get; set; }
        public bool IsStart { get { return Item == Object.START; } }
        public bool IsGoal { get { return Item == Object.GOAL; } }
        public bool IsBlocked { get { return Item == Object.WALL; } }
    }
}
