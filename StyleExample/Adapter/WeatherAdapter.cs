
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

namespace StyleExample.Adapter
{
    public class WeatherItem
    {
        #region properties
        public string Date
        {
            get;
            set;
        }

        public string Celsius
        {
            get;
            set;
        }
        #endregion

        #region ctor
        public WeatherItem(string title, string celsius)
        {
            this.Date = title;
            this.Celsius = celsius;
        }
        #endregion
    }

    public class WeatherItemAdapter : BaseAdapter<WeatherItem> 
    {
        List<WeatherItem> items;
        Activity context;

        public WeatherItemAdapter(Activity context, List<WeatherItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override WeatherItem this[int position]
        {
            get { return items[position]; }
        }

        public override int Count
        {
            get { return items.Count; }
        }

        public override View GetView(int position, View convertView, ViewGroup parent)
        {
            var item = items[position];
            View view = convertView;
            //if (view as ) // no view to re-use, create new
            view = context.LayoutInflater.Inflate(Resource.Layout.WeatherItem, null);
            view.FindViewById<TextView>(Resource.Id.DateText).Text = item.Date;
            view.FindViewById<TextView>(Resource.Id.Celsius).Text = item.Celsius;
            return view;
        }
    }
}
