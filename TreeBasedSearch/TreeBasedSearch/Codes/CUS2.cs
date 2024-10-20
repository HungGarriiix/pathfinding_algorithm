using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class CUS2: PathFinder
    {
        // Algorithm: Dijkstra Search
        // Traversing nodes with lowest distance to find the shortest path with "brain".
        // P/s: This algorithm focuses on precision than performance (certainly faster than others besides GBFS)
        public CUS2(Map map, IMapUI mapUI) : base(map, mapUI)
        {

        }

        public override bool Move(Node source)
        {
            // Initial threshold is the heuristic value from the start node to the goal
            int threshold = GetHeuristic(source.CurrentCell, _map.Goals);
            Console.WriteLine(threshold);
            while (true)
            {
                // Keep track of the next minimum threshold
                int min = int.MaxValue;
                Stack<Node> stack = new Stack<Node>();
                stack.Push(source);

                // Set to track visited cells during this iteration
                HashSet<Cell> visitedInCurrentIteration = new HashSet<Cell>();
                visitedInCurrentIteration.Add(source.CurrentCell);

                while (stack.Count > 0)
                {
                    Node node = stack.Pop();
                    Console.WriteLine($"To {node.CurrentCell.X}, {node.CurrentCell.Y} with h = {node.Heuristic} and min {min}");
                    // Calculate F = G + H (G: current path cost, H: heuristic)
                    int f = node.Distance + node.Heuristic;

                    if (f > threshold)
                    {
                        // If f exceeds threshold, track it as a candidate for the next iteration
                        min = Math.Min(min, f);
                        Console.WriteLine($"Prunned and min = {min}");
                        continue;
                    }

                    TraverseTo(node);

                    // If the goal is reached, print the path and return true
                    if (node.CurrentCell.IsGoal)
                    {
                        _end = node;
                        return true;
                    }

                    // Get neighbors for expansion
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
                // Clear visitedInCurrentIteration to allow a fresh exploration with the new threshold
                visitedInCurrentIteration.Clear();
                _map.ResetVisited();
            }
        }
    }
}
