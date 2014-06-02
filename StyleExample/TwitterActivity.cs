
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
using Android.Text;
using Android.Content.PM;

namespace StyleExample
{
    [Activity(Label = "TwitterActivity", ScreenOrientation = ScreenOrientation.Portrait)]				
    public class TwitterActivity : BaseActivity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetTheme(Resource.Style.Theme_NoTitlebar);

            SetContentView(Resource.Layout.TwitterLayout);

            TextView tweetsView = FindViewById<TextView>(Resource.Id.TweetTextView);
            ISpanned result = Android.Text.Html.FromHtml(Resources.GetString(Resource.String.TweetText));
            tweetsView.SetText(result, TextView.BufferType.Spannable);

            TextView TweetProfileView = FindViewById<TextView>(Resource.Id.TweetProfileView);
            TweetProfileView.SetText(result, TextView.BufferType.Spannable);
            //SupportActionBar.SetDisplayHomeAsUpEnabled(true);
        }
    }
}

