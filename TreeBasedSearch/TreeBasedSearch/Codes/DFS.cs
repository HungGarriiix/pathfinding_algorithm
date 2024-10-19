using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class DFS: PathFinder
    {
        // Algorithm: Depth First Search
        // Finds a path by expanding a node branch until a gooal is reached
        // P/s: 
        public DFS(Map map, IMapUI mapUI): base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            TraverseTo(source);

            if (source.CurrentCell.IsGoal)
            {
                _end = source;
                return true;
            }

            // Just go to other neighbors
            List<Node> neighbors = GetNeighbors(source);
            foreach (Node node in neighbors)
            {
                bool pathFound = Move(node); // No return here to leave room for other neighbors
                if (pathFound) return true; // Exit early if reach goal
            }

            // If there is no path left (no neighbors left)
            return false;
        }
    }
}
