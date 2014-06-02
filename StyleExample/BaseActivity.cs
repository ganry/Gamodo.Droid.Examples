/// <summary>
/// Kälte Eckert app
/// 
/// Copyright (c) 2014 medialis.net, Henry Keller <keller@medialis.net>
/// </summary>

using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Graphics;
using System.Collections.Generic;
using Xamarin.ActionbarSherlockBinding;
using Xamarin.ActionbarSherlockBinding.App;
using Xamarin.ActionbarSherlockBinding.Views;
using SherlockActionBar = Xamarin.ActionbarSherlockBinding.App.ActionBar;
using Android.Content.PM;

using Android.Views.InputMethods;
using System.Threading;

namespace StyleExample
{
    [Activity(Label = "BaseActivity", Icon = "@drawable/icon", ScreenOrientation = ScreenOrientation.Portrait)]	
    [IntentFilter (new string [] { Intent.ActionMain },
        Categories = new string [] { Intent.CategoryDefault  })]
    public class BaseActivity : SherlockActivity, ActionBarSherlock.IOnCreateOptionsMenuListener
    {
        #region fields

        #endregion

        #region ctor

        #endregion

        #region methods
        public void CloseKeyboard(EditText et)
        {
            InputMethodManager imm = (InputMethodManager)GetSystemService(Context.InputMethodService);
            //imm.HideSoftInputFromInputMethod(et.WindowToken, Android.Views.InputMethods.HideSoftInputFlags.ImplicitOnly);
            imm.HideSoftInputFromWindow(et.ApplicationWindowToken, Android.Views.InputMethods.HideSoftInputFlags.None);
            imm.HideSoftInputFromInputMethod(et.WindowToken, HideSoftInputFlags.None);
        }

        protected void closeWithAnimation()
        {
            Finish();
            OverridePendingTransition(Resource.Animation.left_slide_in, Resource.Animation.right_slide_out);
        }

        protected void startNewActivity(Type activity)
        {
            StartActivity(activity);
            OverridePendingTransition(Resource.Animation.right_slide_in, Resource.Animation.left_slide_out);
        }

        public void ShowLink(string link)
        {
            try
            {
                //link has to start with http:// or https:// otherwise we get an exception
                if (!link.StartsWith("http://") && !link.StartsWith("https://"))
                    link = "http://" + link;

                Intent browserIntent = new Intent(Intent.ActionView, Android.Net.Uri.Parse(link));
                StartActivity(browserIntent);
                OverridePendingTransition(Resource.Animation.left_slide_in, Resource.Animation.right_slide_out);
            }
            catch (Exception e)
            {
                Android.Util.Log.Info("BaseActivity", string.Format("Exception in ShowLink, Link: {0}, Error: {1}", link, e.Message));
            }
        }

        public void ShowDialPad(string tel)
        {
            try
            {
                tel = tel.Replace("Tel.:", "");
                if (!tel.StartsWith("tel:"))
                    tel = "tel:" + tel;
                Intent callIntent = new Intent(Intent.ActionView);
                callIntent.SetData(Android.Net.Uri.Parse(tel));
                StartActivity(callIntent);
            }
            catch (Exception e)
            {
                Android.Util.Log.Info("BaseActivity", string.Format("Exception in ShowDialPad, Tel: {0}, Error: {1}", tel, e.Message));
            }
        }

        public void ShowMap(float latitude, float longitude, string name)
        {
            try
            {
                var geoUri = Android.Net.Uri.Parse("geo:" + latitude.ToString() + "," + longitude.ToString() + "(" + name + ")");
                var mapIntent = new Intent(Intent.ActionView, geoUri);
                StartActivity(mapIntent);
                OverridePendingTransition(Resource.Animation.left_slide_in, Resource.Animation.right_slide_out);
            }
            catch (Exception e)
            {
                Android.Util.Log.Info("BaseActivity", string.Format("Exception in ShowMap, Message: {0}", e.Message));
            }
        }        

        public void LaunchGoogleMaps(Context context, double latitude, double longitude, string label) 
        {
            String uriBegin = "geo:" + latitude.ToString().Replace(",", ".") + "," + longitude.ToString().Replace(",", ".") ;
            String query = latitude.ToString().Replace(",", ".")  + "," + longitude.ToString().Replace(",", ".")  + "(" + label + ")";
            String encodedQuery = query;
            String uriString = uriBegin + "?q=" + encodedQuery + "&z=16";
            var uri = Android.Net.Uri.Parse(uriString);
            Intent intent = new Intent(Intent.ActionView, uri);
            StartActivity(intent);
            OverridePendingTransition(Resource.Animation.right_slide_in, Resource.Animation.left_slide_out);
        }

        #endregion

        #region events


        protected override void OnCreate (Bundle bundle)
        {
            SetTheme(Resource.Style.Theme_Styled);
            base.OnCreate (bundle);

        }

        //Native phone back button pressed
        public override void OnBackPressed()
        {
            closeWithAnimation();
        }
        #endregion
    }
}

