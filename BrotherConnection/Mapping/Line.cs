using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrotherConnection.Mapping
{
    class Line
    {
        public Int32 Number { get; set; }
        public String Symbol { get; set; }
        public List<Item> Items { get; set; }
    }
}
