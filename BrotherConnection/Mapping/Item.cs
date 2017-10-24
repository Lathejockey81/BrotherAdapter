using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace BrotherConnection.Mapping
{
    class Item
    {
        public String Name { get; set; }
        public Int32 Length { get; set; }
        public String Type { get; set; }
        public List<EnumValue> EnumValues { get; set; }
    }
}
