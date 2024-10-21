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
        private int _distance;

        public Node(Cell currentCell, Direction direction, int distance = 0, Node parent = null, int heuristic = 0)
        {
            _currentCell = currentCell;
            _direction = direction;
            _parent = parent;
            _heuristic = heuristic;
            _distance = distance;
        }

        public Cell CurrentCell { get { return _currentCell; } }
        public Direction Direction { get { return _direction; } }
        public Node Parent { get { return _parent;} }
        public int Heuristic { get { return _heuristic; } }
        public int Distance { get { return _distance; } }
    }
}
