using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class Coordinate
    {
        // For Swinburne text file config
        public Coordinate(string[] coordinates)
        {
            // For simple coords
            if (coordinates.Length == 2)
            {
                X = int.Parse(coordinates[1]);
                Y = int.Parse(coordinates[0]);
                Wide = 0;
                High = 0;
            }

            // For blocks of coords
            if (coordinates.Length == 4)
            {
                X = int.Parse(coordinates[1]);
                Y = int.Parse(coordinates[0]);
                Wide = int.Parse(coordinates[2]);
                High = int.Parse(coordinates[3]);
            }
        }

        // True coordinate
        public Coordinate(int x, int y)
        {
            X = x;
            Y = y;
            Wide = 0;
            High = 0;
        }

        public int X {  get; set; }
        public int Y { get; set; }
        public int? Wide { get; set; }
        public int? High { get; set; }

        // To calculate the new coords based on a cell
        public static Coordinate GetNewMove(Cell a, Coordinate b)
        {
            return new Coordinate(a.X + b.X, a.Y + b.Y);
        }
    }
}
