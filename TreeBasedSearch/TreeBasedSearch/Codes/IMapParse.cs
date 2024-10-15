using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public interface IMapParse
    {
        Map ParseMap(string filePath);
    }
}
