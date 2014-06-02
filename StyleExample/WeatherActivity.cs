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
using StyleExample.Adapter;

namespace StyleExample
{
    [Activity(Label = "WeatherActivity")]
    public class WeatherActivity : BaseActivity
    {

        List<WeatherItem> weatherList;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.WeatherLayout);

            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
            loadWeather();
        }

        private void loadWeather()
        {
            weatherList = new List<WeatherItem>();
            weatherList.Add(new WeatherItem("SAT 11/10", "22°"));
            weatherList.Add(new WeatherItem("SUN 12/10", "25°"));
            weatherList.Add(new WeatherItem("MON 13/10", "30°"));
            weatherList.Add(new WeatherItem("TUE 14/10", "31°"));
            weatherList.Add(new WeatherItem("WED 15/10", "27°"));
            weatherList.Add(new WeatherItem("THU 16/10", "34°"));
            weatherList.Add(new WeatherItem("FRI 17/10", "32°"));
            weatherList.Add(new WeatherItem("SAT 18/10", "17°"));
            weatherList.Add(new WeatherItem("SUN 19/10", "22°"));
            weatherList.Add(new WeatherItem("MON 20/10", "24°"));
            weatherList.Add(new WeatherItem("TUE 21/10", "28°"));
            weatherList.Add(new WeatherItem("WED 22/10", "35°"));
            weatherList.Add(new WeatherItem("FRI 23/10", "30°"));
            weatherList.Add(new WeatherItem("SAT 25/10", "31°"));
            weatherList.Add(new WeatherItem("SUN 26/10", "32°"));


            ListView menuView = (ListView)FindViewById(Resource.Id.WeatherListView);
            menuView.Adapter = new WeatherItemAdapter(this, weatherList);
        }
    }
}