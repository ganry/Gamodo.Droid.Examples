using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using StyleExample.Adapter;
using System.Collections.Generic;
using Xamarin.ActionbarSherlockBinding.App;

namespace StyleExample
{
    [Activity(Label = "StyleExample", MainLauncher = true)]
    public class MainActivity : BaseActivity
    {
        private List<MenuItem> menuList;

        protected override void OnCreate(Bundle bundle)
        {
            SetTheme(Resource.Style.Theme_Styled);
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);
            SupportActionBar.SetDisplayHomeAsUpEnabled (false); 

            loadMenu();
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

        private void loadMenu()
        {
            menuList = new List<MenuItem>();
            menuList.Add(new MenuItem("User Login Example", Resource.Drawable.user_login));
            menuList.Add(new MenuItem("Twitter Example", Resource.Drawable.twitter_menu_icon));
            menuList.Add(new MenuItem("Weather Example", Resource.Drawable.weather_menu_icon));

            ListView menuView = (ListView)FindViewById(Resource.Id.MenuListView);
            menuView.Adapter = new MenuItemAdapter(this, menuList);
            menuView.ItemClick += OnMenuItemClick;
        }

        protected void OnMenuItemClick(object sender, Android.Widget.AdapterView.ItemClickEventArgs e)
        {
            switch (e.Id)
            {
                //Login Example
                case 0:
                    startNewActivity(typeof(LoginActivity));
                    break;

                //Twitter Example
                case 1:
                    startNewActivity(typeof(TwitterActivity));
                    break;

                //Weather Example
                case 2:
                    startNewActivity(typeof(WeatherActivity));
                    break;

                case 3:
                    break;
            }
        }
    }
}


