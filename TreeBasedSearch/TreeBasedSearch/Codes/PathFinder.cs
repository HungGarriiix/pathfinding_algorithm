using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public abstract class PathFinder
    {
        protected Map _map;
        protected Node _start;
        protected IMapUI _mapUI;
        protected Dictionary<Direction, Coordinate> _directions;

        protected PathFinder(Map map, IMapUI mapUI) 
        {
            _map = map;
            _mapUI = mapUI;
            _start = new Node(_map.Start, Direction.NONE);

            _directions = new Dictionary<Direction, Coordinate>
            {
                { Direction.UP, new Coordinate(-1, 0) },
                { Direction.RIGHT, new Coordinate(0, 1) },
                { Direction.DOWN, new Coordinate(1, 0) },
                { Direction.LEFT, new Coordinate(0, -1) }
            };
        }

        public abstract bool Move(Node source);

        public void Search()
        {
            if (!Move(_start))
            {
                Console.WriteLine("No path found.");
            }
            _map.ResetVisited();
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
            List<Cell> pathCells = new List<Cell>();
            Node current = goalNode;
            while (current != null)
            {
                path.Add(current.Direction.ToString());
                pathCells.Add(current.CurrentCell);
                current = current.Parent;
            }
            path.Reverse();  // Reverse the path to get the correct order
            pathCells.Reverse(); // Same goes here
            _mapUI.ShowRoute(pathCells.ToArray());
            Console.WriteLine($"[ {string.Join(", ", path)} ]");
        }
    }
}
