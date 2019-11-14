using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace OsloBysykkelAPIConsumption.Models
{
    public class Station
    {
        public string station_id { get; set; }
        public string name { get; set; }
        public string address { get; set; }
        public double lat { get; set; }
        public double lon { get; set; }
        public int capacity { get; set; }
        public int is_installed { get; set; }
        public int is_renting { get; set; }
        public int num_bikes_available { get; set; }
        public int num_docks_available { get; set; }
        public int last_reported { get; set; }
        public int is_returning { get; set; }
    }
}
