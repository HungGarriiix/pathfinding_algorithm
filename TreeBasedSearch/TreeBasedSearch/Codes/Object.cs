using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TreeBasedSearch.Codes
{
    public enum Object
    {
        [Description("G")]
        GOAL,
        [Description(".")]
        START,
        [Description(" ")]
        PATH,
        [Description("W")]
        WALL
    }
}
