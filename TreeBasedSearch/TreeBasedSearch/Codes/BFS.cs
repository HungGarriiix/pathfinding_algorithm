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
        public BFS(Map map, IMapUI mapUI) : base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            Queue<Node> queue = new Queue<Node>();
            queue.Enqueue(_start);

            while (queue.Count > 0)
            {
                Node currentNode = queue.Dequeue();

                // Check if we reached the goal
                if (currentNode.CurrentCell.IsGoal)
                {
                    Console.WriteLine("Goal found!");
                    PrintPath(currentNode);
                    return true;
                }

                List<Node> neighbors = GetNeighbors(currentNode);
                foreach (Node neighbor in neighbors)
                {
                    if (!neighbor.CurrentCell.IsVisited)
                    {
                        neighbor.CurrentCell.IsVisited = true;
                        _mapUI.MoveAgent(neighbor.CurrentCell);
                        queue.Enqueue(neighbor);
                    }
                }
            }

            // If there is no path yet
            return false;
        }
    }
}
