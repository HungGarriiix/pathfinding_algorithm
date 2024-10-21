using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public abstract class PathFinder
    {
        protected Map _map;
        protected Node _start;
        protected Node _end;
        protected IMapUI _mapUI;
        protected int _traversedNodesNo;
        protected Dictionary<Direction, Coordinate> _directions;

        protected PathFinder(Map map, IMapUI mapUI) 
        {
            _map = map;
            _mapUI = mapUI;
            _start = new Node(_map.Start, Direction.NONE);
            _end = null; // This will be filled after the search is done
            _traversedNodesNo = 0;

            _directions = new Dictionary<Direction, Coordinate>
            {
                { Direction.UP, new Coordinate(-1, 0) },
                { Direction.RIGHT, new Coordinate(0, 1) },
                { Direction.DOWN, new Coordinate(1, 0) },
                { Direction.LEFT, new Coordinate(0, -1) }
            };
        }

        // Main algorithm goes here (by creating child class of PathFinder and implement this function)
        public abstract bool Move(Node source);

        public int GetHeuristic(Cell source, Cell[] targets)
        {
            // Heuristic value must be admissive (underestimating, get minimum) for all goals
            // Distance: Euclidean method
            return (int)targets.Min(target =>
                Math.Sqrt(Math.Pow(target.X - source.X, 2) + Math.Pow(target.Y - source.Y, 2)));
            // P/s: Why int? - Because I prefer rounded numbers
        }

        public void Search()
        {
            // Re-draw the map UI so that it won't overlapses other algorithm path
            _mapUI.RedrawMap();

            // Start moving from the start node
            if (Move(_start))
                PrintPath(_end);
            else
                PrintNotFound();

            _map.ResetVisited();
        }

        protected void TraverseTo(Node node)
        {
            node.CurrentCell.IsVisited = true;
            _traversedNodesNo++;
            _mapUI.MoveAgent(node.CurrentCell);
        }

        protected List<Node> GetNeighbors(Node source)
        {
            List<Node> neighbors = new List<Node>();
            foreach (var direction in _directions)
            {
                Coordinate newCoords = Coordinate.GetNewMove(source.CurrentCell, direction.Value);
                if (_map.IsAvailable(newCoords))    // Not limited to non-traversable, visited is also listed out
                {
                    Cell cell = _map.Grid[newCoords.X, newCoords.Y];
                    Node node = new Node(cell, direction.Key, source.Distance + 1, source, 
                        GetHeuristic(cell, _map.Goals));
                    neighbors.Add(node);
                }
            }

            return neighbors;
        }

        private void PrintPath(Node goalNode)
        {
            List<string> path = new List<string>();
            List<Cell> pathCells = new List<Cell>();
            Node current = goalNode;

            // Now traverse from the goal node to the start node
            while (current != null)
            {
                if (current.Direction != Direction.NONE)    // No need to add start node at this point
                    path.Add(current.Direction.ToString());
                pathCells.Add(current.CurrentCell);
                current = current.Parent;
            }
            path.Reverse();  // Reverse the path to get the correct order
            pathCells.Reverse(); // Same goes here

            _mapUI.ShowRoute(pathCells.ToArray());

            // Format (from my Uni named Swin)
            // filename method
            // goal number_of_nodes
            // path
            Console.WriteLine($"{_map.FilePath} {this.GetType().Name}");
            Console.WriteLine($"<Node ({goalNode.CurrentCell.X}, {goalNode.CurrentCell.Y})> {_traversedNodesNo}");
            Console.WriteLine($"[ {string.Join(", ", path)} ]\n");
        }

        private void PrintNotFound()
        {
            // Format (from my Uni named Swin)
            // filename method
            // No goal is reachable; number_of_nodes
            Console.WriteLine($"{_map.FilePath} {this.GetType().Name}");
            Console.WriteLine($"No goal is reachable; {_traversedNodesNo}");
        }
    }
}
