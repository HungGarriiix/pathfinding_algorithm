using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class BFS: PathFinder
    {   
        // Algorithm: Breadth First Search
        // Traverse nodes expanded within N depth (horizontally) to search for goal
        // P/s: 
        public BFS(Map map, IMapUI mapUI) : base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            // A queue is needed to store expanded nodes
            // To reduce number of time needed to traverse from branches to branches.
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(_start);

            while (queue.Count > 0) // Finds until the tree cannot be expanded anymore
            {
                Node currentNode = queue.Dequeue();

                if (currentNode.CurrentCell.IsGoal)
                {
                    PrintPath(currentNode);
                    return true;
                }

                List<Node> neighbors = GetNeighbors(currentNode);
                foreach (Node neighbor in neighbors)
                {
                    neighbor.CurrentCell.IsVisited = true;
                    _mapUI.MoveAgent(neighbor.CurrentCell);
                    queue.Enqueue(neighbor);
                }
            }

            // If there is no path yet
            return false;
        }
    }
}
