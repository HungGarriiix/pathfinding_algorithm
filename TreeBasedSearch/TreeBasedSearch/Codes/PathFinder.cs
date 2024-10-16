using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class PathFinder
    {
        private Map _map;
/*        private List<Cell> _visited;
        private Stack<Node> _stack;*/
        private Node _start;
        private Dictionary<Direction, Coordinate> _directions;


        public PathFinder(Map map) 
        {
            _map = map;
/*            _visited = new List<Cell>();
            _stack = new Stack<Node>();*/
            _start = new Node(_map.Start, Direction.NONE);

            _directions = new Dictionary<Direction, Coordinate>
            {
                { Direction.UP, new Coordinate(-1, 0) },
                { Direction.RIGHT, new Coordinate(0, 1) },
                { Direction.DOWN, new Coordinate(1, 0) },
                { Direction.LEFT, new Coordinate(0, -1) }
            };
        }

        public void Search()
        {
            if (!DFS(_start))
            {
                Console.WriteLine("No path found.");
            }
        }

        public bool DFS(Node source)
        {
            source.CurrentCell.IsVisited = true;

            if (source.CurrentCell.IsGoal)
            {
                PrintPath(source);
                return true;
            }

            List<Node> neighbors = GetNeighbors(source);
            foreach (Node node in neighbors) 
            {
                bool pathFound = DFS(node); // No return here to leave room for other neighbors
                if (pathFound) return true; // Exit early if reach goal
            }

            // If there is no path left (no neighbors left)
            return false;
        }

        public List<Node> GetNeighbors(Node source)
        {
            List<Node> neighbors = new List<Node>();
            foreach (var direction in _directions)
            {
                Coordinate newCoords = Coordinate.GetNewMove(source.CurrentCell, direction.Value);
                if (_map.IsAvailable(newCoords))
                {
                    Node node = new Node(_map.Grid[newCoords.X, newCoords.Y], direction.Key, source);
                    neighbors.Add(node);
                }
            }

            return neighbors;
        }

        public void PrintPath(Node goalNode)
        {
            List<string> path = new List<string>();
            Node current = goalNode;
            while (current != null)
            {
                path.Add(current.Direction.ToString());
                current = current.Parent;
            }
            path.Reverse();  // Reverse the path to get the correct order
            Console.WriteLine($"[ {string.Join(", ", path)} ]");
        }

    }
}
