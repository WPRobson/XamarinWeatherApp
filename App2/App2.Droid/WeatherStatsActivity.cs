using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Android.App;
using Android.Content;
using Android.OS;
using Android.Runtime;
using Android.Views;
using Android.Widget;

namespace App2.Droid
{
    [Activity(Label = "WeatherStatsActivity")]
    public class WeatherStatsActivity : Activity
    {

        GetWeather weatherLogic = new GetWeather();
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WeatherStats);

            string passedData = Intent.GetStringExtra("weatherData") ?? "data not available";

            if (passedData != "data not available")
            {
                Rootobject weatherObject = weatherLogic.ConventToWeatherObject(passedData);
                setWeatherValues(weatherObject);
            }




            // Create your application here
        }

        void setWeatherValues(Rootobject data)
        {
          
            Clouds clouds = data.list[0].clouds;
            Main main = data.list[0].main;
            Weather[] weather = data.list[0].weather;
            Wind wind = data.list[0].wind;
            Rain rain = data.list[0].rain;

            TextView cloudsText = FindViewById<TextView>(Resource.Id.cloudsText);
            TextView groudLevelText = FindViewById<TextView>(Resource.Id.groundLevelText);
            TextView HumidityText = FindViewById<TextView>(Resource.Id.humidityText);
            TextView PressureText = FindViewById<TextView>(Resource.Id.pressureText);
            TextView tempText = FindViewById<TextView>(Resource.Id.tempText);
            TextView weatherDesText = FindViewById<TextView>(Resource.Id.weatherDescText);
            TextView windSpeedText = FindViewById<TextView>(Resource.Id.windspeedText);

            cloudsText.Text = clouds.all.ToString();
            groudLevelText.Text = main.grnd_level.ToString();
            HumidityText.Text = main.humidity.ToString();
            PressureText.Text = main.pressure.ToString();
            tempText.Text = main.temp.ToString();
            weatherDesText.Text = weather[0].description;
            windSpeedText.Text = wind.speed.ToString();




        }
    }
}