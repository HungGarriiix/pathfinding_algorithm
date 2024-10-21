using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class CUS1: PathFinder
    {
        // Algorithm: Dijkstra Search
        // Traversing nodes with lowest distance to find the shortest path with "brain".
        // P/s: This algorithm focuses on precision than performance (certainly faster than others besides GBFS)
        public CUS1(Map map, IMapUI mapUI) : base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            // At first, a queue is needed to pop the nodes out
            // However, the queue must be sorted frequently per neighbors added, a generic list is more suitable
            List<Node> nodesInQueue = new List<Node>();
            nodesInQueue.Add(source);

            while (nodesInQueue.Count > 0)
            {
                // Get the prioritized node first (based on lowest distance)
                Node prioritizedNode = nodesInQueue[0];
                TraverseTo(prioritizedNode);

                if (prioritizedNode.CurrentCell.IsGoal)
                {
                    _end = prioritizedNode;
                    return true;
                }

                nodesInQueue.AddRange(GetNeighbors(prioritizedNode));

                // Now sort based on distance
                nodesInQueue.Sort((node1, node2) => node1.Distance.CompareTo(node2.Distance));
                // Try to remove the node of the list, same as the queue functionality
                nodesInQueue.Remove(prioritizedNode);
                for (int i = nodesInQueue.Count - 1; i >= 0; i--) // The cell has been visited, so other Nodes with associated Cell must be cut out
                    if (prioritizedNode.CurrentCell == nodesInQueue[i].CurrentCell)
                        nodesInQueue.RemoveAt(i);
            }

            // Failed to find a path
            return false;
        }
    }
}
