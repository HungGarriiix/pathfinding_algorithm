using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class Node
    {
        private Cell _currentCell;
        private Direction _direction;
        private Node _parent;
        private int _heuristic;

        public Node(Cell currentCell, Direction direction, Node parent = null, int heuristic = 0)
        {
            _currentCell = currentCell;
            _direction = direction;
            _parent = parent;
            _heuristic = heuristic;
        }

        public Cell CurrentCell { get { return _currentCell; } }
        public Direction Direction { get { return _direction; } }
        public Node Parent { get { return _parent;} }
        public int Heuristic { get { return _heuristic; } }
    }
}
