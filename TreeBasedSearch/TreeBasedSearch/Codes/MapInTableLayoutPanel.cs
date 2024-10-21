using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeBasedSearch.Codes
{
    public class MapInTableLayoutPanel: IMapUI
    {
        private Dictionary<Object, Color> _objectColors;
        private Color _visitedColor = Color.Purple;
        private Color _routeColor = Color.SkyBlue;
        private const int ANIM_DELAY = 500; 

        public MapInTableLayoutPanel(Map map, TableLayoutPanel mapUI) 
        {
            GridMap = map;
            MapUI = mapUI;
            _objectColors = new Dictionary<Object, Color>
            {
                { Object.PATH, Color.White},
                { Object.GOAL, Color.Green },
                { Object.START, Color.Red },
                { Object.WALL, Color.DarkGray }
            };
            // Clean the map everytime a new map is loaded
            // to ensure no fautly under any circumstances
            MapUI.SuspendLayout();
            ClearMap();

            MapUI.ColumnCount = GridMap.Columns;
            MapUI.RowCount = GridMap.Rows;
            MapUI.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;

            for (int i = 0; i < GridMap.Columns; i++)
            {
                MapUI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / GridMap.Columns));
            }
            for (int j = 0; j < GridMap.Rows; j++)
            {
                MapUI.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / GridMap.Rows));
            }

            DrawMap();
            MapUI.ResumeLayout(true);
        }

        public Map GridMap { get; set; }
        public TableLayoutPanel MapUI { get; set; }

        public void ClearMap()
        {
            for (int i = MapUI.Controls.Count - 1; i >= 0; i--)
            {
                MapUI.Controls[i].Dispose();
            }
            
            MapUI.Controls.Clear();
            MapUI.ColumnStyles.Clear();
            MapUI.RowStyles.Clear();
            MapUI.ColumnCount = 0;
            MapUI.RowCount = 0;
        }

        public void DrawMap()
        {
            for (int x = 0; x < GridMap.Rows; x++)
            {
                for (int y = 0; y < GridMap.Columns; y++)
                {
                    MapUI.Controls.Add(CreateCell(GridMap.Grid[x, y]));
                }
            }
        }

        public Panel CreateCell(Cell cell)
        {
            return new Panel
            {
                Dock = DockStyle.Fill,
                BackColor = _objectColors[cell.Item]
            };
        }

        public int GetIndex(Cell position)
        {
            return (position.X * (GridMap.Columns)) + position.Y;
        }

        public void MoveAgent(Cell position)
        {
            if (!position.IsGoal && !position.IsStart)
                MapUI.Controls[GetIndex(position)].BackColor = _visitedColor;
        }

        public void ShowRoute(Cell[] routes)
        {
            foreach (Cell node in routes)
                if (!node.IsGoal && !node.IsStart)
                    MapUI.Controls[GetIndex(node)].BackColor = _routeColor;
        }

        public void RedrawMap()
        {
            foreach (Cell cell in GridMap.Grid)
                MapUI.Controls[GetIndex(cell)].BackColor = _objectColors[cell.Item];
        }
    }
}
