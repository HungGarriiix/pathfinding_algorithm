using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms.VisualStyles;

namespace TreeBasedSearch.Codes
{
    public class TextFileParse: IMapParse
    {
        public Map ParseMap(string filePath)
        {
            string[] lines = File.ReadAllLines(filePath);

            // Parse grid size
            string[] gridSize = lines[0].Trim('[', ']').Split(',');
            int rows = int.Parse(gridSize[0]);
            int columns = int.Parse(gridSize[1]);

            // Parse start location
            string[] startLoc_text = lines[1].Trim('(', ')').Split(',');
            Coordinate startLoc = new Coordinate(startLoc_text);

            // Parse goal locations
            List<Coordinate> goals = new List<Coordinate>();
            string[] goals_text = lines[2].Split('|');
            foreach (string goal_line in goals_text)
            {
                string[] goal_text = goal_line.Trim('(', ' ', ')').Split(',');
                Coordinate goal = new Coordinate(goal_text);
                goals.Add(goal);
            }

            // Parse wall locations
            List<Coordinate> walls = new List<Coordinate>();
            for (int i = 3; i < lines.Length; i++)
            {
                string[] wall_text = lines[i].Trim('(', ')').Split(',');
                Coordinate wall = new Coordinate(wall_text);
                walls.Add(wall);
            }

            return new Map(rows, columns, startLoc, goals.ToArray(), walls.ToArray(), filePath);
        }
    }
}
