using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Forms;

namespace TreeBasedSearch.Codes
{
    public class MapInTableLayoutPanel
    {
        private float _cellWidth;
        private float _cellHeight;

        public MapInTableLayoutPanel(Map map, TableLayoutPanel mapUI) 
        {
            GridMap = map;
            MapUI = mapUI;

            ClearMap();
            MapUI.ColumnCount = map.Columns;
            MapUI.RowCount = map.Rows;
            MapUI.CellBorderStyle = TableLayoutPanelCellBorderStyle.Single;
            _cellHeight = MapUI.Size.Height / map.Rows;
            _cellWidth = MapUI.Size.Width / map.Columns;

            for (int i = 0; i < map.Columns; i++)
            {
                MapUI.ColumnStyles.Add(new ColumnStyle(SizeType.Percent, 100f / map.Columns));
            }
            for (int j = 0; j < map.Rows; j++)
            {
                MapUI.RowStyles.Add(new RowStyle(SizeType.Percent, 100f / map.Rows));
            }

            DrawMap();
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
                    MapUI.Controls.Add(CreateCell(GridMap.Grid[x,y]));
                }
            }
        }

        public Panel CreateCell(Cell cell)
        {
            Panel panel = new Panel
            {
                Dock = DockStyle.Fill,
            };

            switch (cell.Item)
            {
                case Object.PATH:
                    panel.BackColor = Color.White;
                    break;
                case Object.GOAL:
                    panel.BackColor = Color.Green;
                    break;
                case Object.START:
                    panel.BackColor = Color.Red;
                    break;
                case Object.WALL:
                    panel.BackColor = Color.DarkGray;
                    break;
            }
            return panel;
        }
    }
}
