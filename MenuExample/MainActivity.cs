using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;

namespace MenuExample
{
    [Activity(Label = "MenuExample", MainLauncher = true)]
    public class MainActivity : Activity
    {
        int count = 1;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button button = FindViewById<Button>(Resource.Id.myButton);
			
            button.Click += delegate
            {
                    StartActivity(typeof(XmlMenuActivity));
            };
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            base.OnCreateOptionsMenu(menu);

            int groupId = 0;

            //Unique menu item identifier. used for event handling.
            int menuItemId = Menu.First;
            //The order position of the item
            int menuItemOrder = Menu.None;
            //Text to be displayed for this menu item
            int menuItemText = Resource.String.hello;

            //Create the menu item and keep a referance to it
            IMenuItem menuItem1 = menu.Add(
                groupId, 
                menuItemId, 
                menuItemOrder, 
                menuItemText);
            menuItem1.SetShortcut('1', 'a');

            int MenuGroup = 10;
            IMenuItem menuItem2 = menu.Add(
                MenuGroup, 
                menuItemId + 10, 
                menuItemOrder + 1, 
                new Java.Lang.String("Menu Item 2"));

            IMenuItem menuItem3 =
                menu.Add(
                    MenuGroup, 
                    menuItemId + 20, 
                    menuItemOrder + 2,
                    new Java.Lang.String("Menu Item 3")
                );

            ISubMenu sub = menu.AddSubMenu(
                0, 
                menuItemOrder + 30,
                menuItemOrder + 3, 
                new Java.Lang.String("Submenu 1")
            );

            sub.SetHeaderIcon(Resource.Drawable.Icon);
            sub.SetIcon(Resource.Drawable.Icon);

            IMenuItem submenuItem = sub.Add(
                0, 
                menuItemId + 40, 
                menuItemOrder + 4,
                new Java.Lang.String("Submenu Item")
            );

            IMenuItem submenuItem2 = 
                sub.Add(
                    MenuGroup, 
                    menuItemId + 50, 
                    menuItemOrder + 5,
                    new Java.Lang.String("sub-1")).SetCheckable(true);

            IMenuItem submenuItem3 =
                sub.Add(
                    MenuGroup, 
                    menuItemId + 60, 
                    menuItemOrder + 6,
                    new Java.Lang.String("sub-2")).SetCheckable(true);
            return true;
        }

        public override bool OnMenuItemSelected(int featureId, IMenuItem item)
        {
            switch (item.ItemId)
            {
                case(0):
                    //menu id 0 was selected.
                    return (true);
                case(1):
                    //menu id 1 was selected
                    return (true);
                    // additional items can go here.
            }
            return (false);
        }
    }
}


