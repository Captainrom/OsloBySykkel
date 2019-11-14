using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsloBysykkelAPIConsumption.Models
{
    public class RootObject
    {
        public int last_updated { get; set; }
        public Data data { get; set; }
    }
}
