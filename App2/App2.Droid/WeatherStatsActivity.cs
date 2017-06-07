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
            string passedData = Intent.GetStringExtra("weatherData") ?? "data not available";

            Rootobject weatherObject =  weatherLogic.ConventToWeatherObject(passedData);

            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.WeatherStats);
            // Create your application here
        }
    }
}