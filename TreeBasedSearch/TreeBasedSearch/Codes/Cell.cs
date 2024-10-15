using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public struct Cell
    {
        public Cell(int x, int y, Object item = Object.PATH)
        {
            X = x;
            Y = y;
            Item = item;
        }

        public int X { get; set; }
        public int Y { get; set; }
        public Object Item { get; set; }
    }
}
