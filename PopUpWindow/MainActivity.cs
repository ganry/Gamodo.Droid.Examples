using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace PopUpWindow
{
    [Activity(Label = "PopUpWindow", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            // Get our button from the layout resource,
            // and attach an event to it
            Button popMenu = FindViewById<Button>(Resource.Id.popupMenuBtn);
            Button popWindow = FindViewById<Button>(Resource.Id.popupWindowBtn);

           
			
            popMenu.Click += delegate
            {
                    PopupMenu menu = new PopupMenu (this, popMenu);

                    // with Android 3 need to use MenuInfater to inflate the menu
                    //menu.MenuInflater.Inflate (Resource.Menu.popup_menu, menu.Menu);

                    // with Android 4 Inflate can be called directly on the menu
                    menu.Inflate (Resource.Menu.popup_menu);

                    menu.MenuItemClick += (s1, arg1) => {
                            Console.WriteLine ("{0} selected", arg1.Item.TitleFormatted);
                        };

                    // Android 4 now has the DismissEvent
                    menu.DismissEvent += (s2, arg2) => {
                            Console.WriteLine ("menu dismissed"); 
                        };

                    menu.Show ();
            };

            popWindow.Click += delegate
                {
                    LayoutInflater inflater = (LayoutInflater) this.GetSystemService(Context.LayoutInflaterService); 

                    PopupWindow pw = new PopupWindow(inflater.Inflate(Resource.Layout.popup_example, null, false),200,250, true);

                    pw.ShowAtLocation(this.FindViewById(Resource.Id.main), GravityFlags.Center, 0, 0);
                    Button closePopup = (Button)pw.ContentView.FindViewById(Resource.Id.closePopup);
                    closePopup.Click += delegate {
                            pw.Dismiss();
                    };
                };
        }
    }
}


