using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Net.Http;
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;

namespace Converter
{
    class CurrencyService
    {
        string URL = "https://v6.exchangerate-api.com/v6/ed1b90d3840884137fbb7f9e/latest/USD";
        HttpClient client = new HttpClient();
        public async Task<List<Unit>> getCurrencies()
        {
            string result = await client.GetStringAsync(URL);
            JObject jObject = JObject.Parse(result);
            List<Unit> listUnits = new List<Unit>();
            foreach(JProperty property in jObject["conversion_rates"])
            {
                Unit unitObject = new Unit(property.Name, Double.Parse(property.Value.ToString()));
                listUnits.Add(unitObject);
            }
            return listUnits;
        }

    }
}
