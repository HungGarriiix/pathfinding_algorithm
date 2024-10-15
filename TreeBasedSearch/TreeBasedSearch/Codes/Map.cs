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

        private void CreateMap(Coordinate start, Coordinate[] goals, Coordinate[] walls)
        {
            for (int i = 0; i < Rows; i++)
            {
                for (int j = 0; j < Columns; j++)
                {
                    _grid[i, j] = new Cell(i, j); // Default as free space (null)
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
        }

        private void AddGoals(Coordinate[] goals)
        {
            foreach (Coordinate goal in goals)
            {
                Cell goalCell = new Cell(goal.X, goal.Y, Object.GOAL);
                _grid[goal.X, goal.Y] = goalCell;
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
    }
}
