
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

namespace MenuExample
{
    [Activity(Label = "XmlMenuActivity")]			
    public class XmlMenuActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);
            MenuInflater inflater = new MenuInflater(this);
            inflater.Inflate(Resource.Layout.XmlMenu, menu);
            return true;
        }
    }
}

