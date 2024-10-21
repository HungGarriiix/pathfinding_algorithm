using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class CUS2: PathFinder
    {
        // Algorithm: Iterative Deepening A* (IDA*)
        // Similar to A*, with some memory constrains applied
        // P/s: This algorithm focuses on memory management than performance, while the precision of A* still kept
        public CUS2(Map map, IMapUI mapUI) : base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            // Initial threshold is the heuristic value from the start node to one of the goal
            int threshold = GetHeuristic(source.CurrentCell, _map.Goals);
            Console.WriteLine(threshold);
            while (true)
            {
                // Keep track of the next minimum threshold
                int min = int.MaxValue;
                Stack<Node> stack = new Stack<Node>();
                stack.Push(source);

                HashSet<Cell> visitedInCurrentIteration = new HashSet<Cell>();
                visitedInCurrentIteration.Add(source.CurrentCell);

                while (stack.Count > 0)
                {
                    Node node = stack.Pop();
                    int f = node.Distance + node.Heuristic;

                    if (f > threshold)
                    {
                        // If f exceeds threshold, track it as a candidate for the next iteration
                        min = Math.Min(min, f);
                        continue;
                    }

                    TraverseTo(node);

                    if (node.CurrentCell.IsGoal)
                    {
                        _end = node;
                        return true;
                    }

                    List<Node> neighbors = GetNeighbors(node);

                    foreach (var neighbor in neighbors)
                    {
                        if (!visitedInCurrentIteration.Contains(neighbor.CurrentCell))
                        {
                            stack.Push(neighbor);
                            visitedInCurrentIteration.Add(neighbor.CurrentCell);
                        }
                    }
                }

                // No solution found within this threshold, increase threshold
                if (min == int.MaxValue)
                {
                    // No more nodes to explore (min is unchanged), meaning no path exists
                    return false;
                }

                threshold = min;
                // Clear the map to allow a fresh exploration with the new threshold
                visitedInCurrentIteration.Clear();
                _map.ResetVisited();
            }
        }
    }
}
