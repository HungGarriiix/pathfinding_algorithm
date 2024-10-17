﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class AS: PathFinder
    {
        public AS(Map map, IMapUI mapUI) : base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            // At first, a queue is needed to pop the nodes out
            // However, the queue must be sorted frequently per neighbors added, a generic list is more suitable
            List<Node> nodesInQueue = new List<Node>();
            nodesInQueue.Add(source);
/*            HashSet<Cell> visited = new HashSet<Cell>();*/

            while (nodesInQueue.Count > 0)
            {
                // Get the prioritized node first (based on lowest F)
                Node prioritizedNode = nodesInQueue[0];
                prioritizedNode.CurrentCell.IsVisited = true;
                _mapUI.MoveAgent(prioritizedNode.CurrentCell);
/*                visited.Add(prioritizedNode.CurrentCell);*/

                if (prioritizedNode.CurrentCell.IsGoal)
                {
                    PrintPath(prioritizedNode);
                    return true;
                }

                nodesInQueue.AddRange(GetNeighbors(prioritizedNode));

                // F = G (distance travelled) + H (heuristic value)
                nodesInQueue.Sort((node1, node2) => (node1.Distance + node1.Heuristic).CompareTo(node2.Distance + node2.Heuristic));
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
