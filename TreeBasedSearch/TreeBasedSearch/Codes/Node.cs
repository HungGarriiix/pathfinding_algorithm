using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class Node
    {
        private readonly Cell _currentCell;
        private readonly Direction _direction;
        private readonly Node _parent;

        public Node(Cell currentCell, Direction direction, Node parent)
        {
            _currentCell = currentCell;
            _direction = direction;
            _parent = parent;
        }
    }
}
