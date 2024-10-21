using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public interface IMapUI
    {
        Map GridMap { get; }

        void ClearMap();
        void DrawMap();
        int GetIndex(Cell position);
        void MoveAgent(Cell position);
        void ShowRoute(Cell[] routes);
        void RedrawMap();
    }
}
