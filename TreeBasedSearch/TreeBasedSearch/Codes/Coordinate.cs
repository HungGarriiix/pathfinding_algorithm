using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class Coordinate
    {
        public Coordinate(string[] coordinates, int no)
        {
            // For simple coords
            if (no == 2)
            {
                X = int.Parse(coordinates[1]);
                Y = int.Parse(coordinates[0]);
                Wide = 0;
                High = 0;
            }

            // For blocks of coords
            if (no == 4)
            {
                X = int.Parse(coordinates[1]);
                Y = int.Parse(coordinates[0]);
                Wide = int.Parse(coordinates[2]);
                High = int.Parse(coordinates[3]);
            }
        }

        public int X {  get; set; }
        public int Y { get; set; }
        public int Wide { get; set; }
        public int High { get; set; }
    }
}
