using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class GBFS: PathFinder
    {
        // Algorithm: Greedy Best First Search
        // Depth first searches for nodes with lowest heuristic value (closer to the goal) to eliminate seemingly unnecessary paths
        // P/s: Just like DFS, with heuristic value to be considered
        //      If there is no path, just backtrack like DFS

        public GBFS(Map map, IMapUI mapUI) : base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            // Imagine this like Depth First Search with heuristic
            TraverseTo(source);

            if (source.CurrentCell.IsGoal)
            {
                _end = source;
                return true;
            }

            // Get neighbors then determine which neighbor has the most potential (lowest heuristic value)
            List<Node> neighbors = GetNeighbors(source);
            neighbors.Sort((node1, node2) => node1.Heuristic.CompareTo(node2.Heuristic));   // Admissive heuristic goes first (ascending)

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
