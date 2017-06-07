
using Android.App;
using Android.Content;
using Android.OS;
using Android.Widget;

namespace App2.Droid
{
	[Activity (Label = "App2.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		
		GetWeather newWeather = new GetWeather();
		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

			// Get our button from the layout resource,
			// and attach an event to it
			Button button = FindViewById<Button> (Resource.Id.myButton);
			
			button.Click += async delegate
			{
				button.Text = "Geting data";

				EditText cityText =  FindViewById<EditText>(Resource.Id.CityInput);
				EditText CountryText = FindViewById<EditText>(Resource.Id.countryInput);


				string city = cityText?.Text;
				string country = CountryText?.Text;

				if (country != null && city != null)
				{
					Rootobject weather = await newWeather.GetWeatherByCity(city, country);
					string extraIntentData = weather.ToString();
					var weatherActivity = new Intent(this,typeof(WeatherStatsActivity));
					weatherActivity.PutExtra("weatherData", extraIntentData);
					StartActivity(weatherActivity);
				}
				
			};
		}
	}
}


