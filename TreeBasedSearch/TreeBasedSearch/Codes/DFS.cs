using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class DFS: PathFinder
    {
        public DFS(Map map, IMapUI mapUI): base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            source.CurrentCell.IsVisited = true;
            _mapUI.MoveAgent(source.CurrentCell);

            if (source.CurrentCell.IsGoal)
            {
                PrintPath(source);
                return true;
            }

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
