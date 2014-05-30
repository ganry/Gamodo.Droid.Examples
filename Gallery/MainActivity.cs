using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace GalleryApp
{
	[Activity (Label = "Gallery", MainLauncher = true)]
	public class MainActivity : Activity
	{
		int count = 1;
		Gallery gallery;

		protected override void OnCreate (Bundle bundle)
		{
			base.OnCreate (bundle);

			// Set our view from the "main" layout resource
			SetContentView (Resource.Layout.Main);

            gallery = FindViewById<Gallery>(Resource.Id.gallery1);
			gallery.Adapter = new ImageAdapter (this);
            RegisterForContextMenu(gallery);
		}

        public override void OnCreateContextMenu(Android.Views.IContextMenu menu, View v,
            Android.Views.IContextMenuContextMenuInfo menuInfo)
        {
            base.OnCreateContextMenu(menu, v, menuInfo);
            Java.Lang.ICharSequence str0 = new Java.Lang.String("Context Menu");
            Java.Lang.ICharSequence str1 = new Java.Lang.String("Item 1");
            Java.Lang.ICharSequence str2 = new Java.Lang.String("Item 2");
            Java.Lang.ICharSequence str3 = new Java.Lang.String("Item 3");
            Java.Lang.ICharSequence strSubMenu = new Java.Lang.String("Submenu");
            Java.Lang.ICharSequence strSubMenuItem = new Java.Lang.String("Submenu Item");
            menu.SetHeaderTitle(str0);
            menu.Add(0, Android.Views.Menu.First,
                Android.Views.Menu.None, str1).SetIcon(Resource.Drawable.Icon);
            menu.Add(0, Android.Views.Menu.First + 1, Android.Views.Menu.None, str2)
                .SetCheckable(true);
            menu.Add(0, Android.Views.Menu.First + 2, Android.Views.Menu.None, str3)
                .SetShortcut('3', '3');
            ISubMenu sub = menu.AddSubMenu(strSubMenu);
            sub.Add(strSubMenuItem);
        }
	}
}


