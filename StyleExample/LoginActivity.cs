
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

namespace StyleExample
{
    [Activity(Label = "LoginActivity")]			
    public class LoginActivity : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            SetContentView(Resource.Layout.LoginLayout);
            SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}

