using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrotherConnection.Mapping
{
    class DataMap
    {
        public String FileName { get; set; }
        public List<Line> Lines { get; set; } = new List<Line>();

    }
}
