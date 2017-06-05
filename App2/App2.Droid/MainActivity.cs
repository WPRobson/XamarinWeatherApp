﻿using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace App2.Droid
{
	[Activity (Label = "App2.Droid", MainLauncher = true, Icon = "@drawable/icon")]
	public class MainActivity : Activity
	{
		int count = 1;

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
				Rootobject weather = await newWeather.GetWeatherByCity("Norwich", "UK");
				button.Text = "Data retrieved";
				
			};
		}
	}
}

