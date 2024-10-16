using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class Map
    {
        private int _rowsNo;
        private int _columnsNo;
        private Cell[,] _grid;

        public Map(int rows, int columns, Coordinate start, Coordinate[] goals, Coordinate[] walls)
        {
            Rows = rows;
            Columns = columns;
            Grid = new Cell[Rows, Columns];
            Start = null;
            Goals = new List<Cell>();

            CreateMap(start, goals, walls);
        }

        public int Rows 
        {  
            get { return _rowsNo; }
            set { _rowsNo = value; }
        }

        public int Columns
        {
            get { return _columnsNo; }
            set { _columnsNo = value; }
        }

        public Cell[,] Grid
        {
            get { return _grid; }
            private set { _grid = value; }
        }

        public Cell Start { get; private set; }
        public List<Cell> Goals { get; private set; }
        public int MaxX { get { return _rowsNo - 1; } }
        public int MinX { get { return 0; } }
        public int MaxY { get { return _columnsNo - 1; } }
        public int MinY { get { return 0; } }

        private void CreateMap(Coordinate start, Coordinate[] goals, Coordinate[] walls)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _grid[i, j] = new Cell(i, j); // Default as free space (Path)
                }
            }

            AddStart(start);
            AddGoals(goals);
            AddObstacles(walls);
        }

        private void AddStart(Coordinate start)
        {
            Cell startCell = new Cell(start.X, start.Y, Object.START);
            _grid[start.X, start.Y] = startCell;
            Start = startCell;
        }

        private void AddGoals(Coordinate[] goals)
        {
            foreach (Coordinate goal in goals)
            {
                Cell goalCell = new Cell(goal.X, goal.Y, Object.GOAL);
                _grid[goal.X, goal.Y] = goalCell;
                Goals.Add(goalCell);
            }
        }

        private void AddObstacles(Coordinate[] walls)
        {
            foreach (Coordinate wall in walls)
            {
                for (int x = wall.X; x < wall.X + wall.High; x++)
                {
                    for (int y = wall.Y; y < wall.Y + wall.Wide; y++)
                    {
                        Cell wallCell = new Cell(x, y, Object.WALL);
                        Grid[x, y] = wallCell;
                    }
                }
            }
        }

        public bool IsAvailable(Coordinate coords)
        {
            // Check for out of bound
            if (!(coords.X <= MaxX && coords.X >= MinX))
                return false;

            if (!(coords.Y <= MaxY && coords.Y >= MinY))
                return false;

            // Check for other status
            Cell loc = Grid[coords.X, coords.Y];
            /*return loc.IsVisited == false || loc.IsBlocked == false;*/
            if (loc.IsVisited) return false;
            if (loc.IsBlocked) return false;

            return true;
        }

        public void ResetVisited()
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _grid[i, j].IsVisited = false;
                }
            }
        }
    }
}
