using Newtonsoft.Json;
using System.Net.Http;
using System.Threading.Tasks;

namespace App2
{
    public class GetWeather
    {
        string apiKey = "ab1d78836a5167c088ff690b2db29bf8";


        public async Task<string> GetWeatherByCity(string city, string country)
        {

            string request = $"http://api.openweathermap.org/data/2.5/forecast?q={city},{country}&appid={apiKey}";

            object responceJson = await SentHttpRequest(request);

            string returnString = JsonConvert.SerializeObject(responceJson);

            //var weatherJson = JsonConvert.SerializeObject(responceJson);
            //Rootobject weatherRoot = JsonConvert.DeserializeObject<Rootobject>(weatherJson);

            return returnString;
        }

        async Task<object> SentHttpRequest(string url)
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

        public Rootobject ConventToWeatherObject(string data)
        {
            //var weatherJson = JsonConvert.SerializeObject(data);
            Rootobject weatherRoot = JsonConvert.DeserializeObject<Rootobject>(data);
            return weatherRoot;

        }




    }
}
