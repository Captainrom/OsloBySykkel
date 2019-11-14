using OsloBysykkelAPIConsumption.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Threading.Tasks;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace OsloBysykkelAPIConsumption.Consumer
{
    public class ApiOsloBySykkel
    {
        private HttpClient client;

        Station station = new Station();

        public ApiOsloBySykkel()
        {
            client = new HttpClient();
            client.DefaultRequestHeaders.Add("client-name", "BySykel Stasjons Liste");
            client.BaseAddress = new Uri("https://gbfs.urbansharing.com/oslobysykkel.no/");
        }

        public async Task<RootObject> GetStationInformation()
        {
            var response = await client.GetAsync("station_information.json");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();

            return JsonConvert.DeserializeObject<RootObject>(result);
        }

        public async Task<RootObject> GetStationStatus()
        {
            var response = await client.GetAsync("station_status.json");
            response.EnsureSuccessStatusCode();
            var result = await response.Content.ReadAsStringAsync();
            
            return JsonConvert.DeserializeObject<RootObject>(result);
        }
    }
}
