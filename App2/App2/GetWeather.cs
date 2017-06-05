using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Newtonsoft.Json;

using System.Net.Http;
using Newtonsoft.Json.Linq;
using System.Threading;

namespace App2
{
    public class GetWeather
    {
        string apiKey = "ab1d78836a5167c088ff690b2db29bf8";


        public async Task<Rootobject> GetWeatherByCity(string city, string country)
        {
            
            string request = $"http://api.openweathermap.org/data/2.5/forecast?q={city},{country}&appid={apiKey}";

            object responceJson = await sendRequest(request);

            var weatherJson = JsonConvert.SerializeObject(responceJson);
            Rootobject weatherRoot = JsonConvert.DeserializeObject<Rootobject>(weatherJson);

            return weatherRoot;
        }

        async Task<object> sendRequest(string url)
        {
            string data = string.Empty;
            using (HttpClient client = new HttpClient())
            {
                var responce = client.GetAsync(url);
                data = await responce.Result.Content.ReadAsStringAsync();
            }

            object result = JsonConvert.DeserializeObject(data);
            return result;
        }




    }
}
