using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public class DFS
    {
        private Map _map;
        private Cell _start;
        private Cell[] _goals;
        private Node _source;

        public DFS(Map map) 
        {
            _map = map;
            _start = map.Start;
            _goals = map.Goals.ToArray();
        }

        public void Execute()
        {

        }

    }
}
