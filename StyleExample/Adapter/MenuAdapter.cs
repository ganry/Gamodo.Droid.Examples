
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
    public class MenuItem
    {
        #region properties
        public string Title
        {
            get;
            set;
        }

        public int ImageResourceId
        {
            get;
            set;
        }
        #endregion

        #region ctor
        public MenuItem(string title, int imageResourceId)
        {
            this.Title = title;
            this.ImageResourceId = imageResourceId;
        }
        #endregion
    }

    public class MenuItemAdapter : BaseAdapter<MenuItem> 
    {
        List<MenuItem> items;
        Activity context;

        public MenuItemAdapter(Activity context, List<MenuItem> items)
            : base()
        {
            this.context = context;
            this.items = items;
        }

        public override long GetItemId(int position)
        {
            return position;
        }

        public override MenuItem this[int position]
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
            view = context.LayoutInflater.Inflate(Resource.Layout.MenuItem, null);
            view.FindViewById<TextView>(Resource.Id.MenuTitle).Text = item.Title;
            view.FindViewById<ImageView>(Resource.Id.Image).SetImageResource(item.ImageResourceId);
            return view;
        }
    }
}
