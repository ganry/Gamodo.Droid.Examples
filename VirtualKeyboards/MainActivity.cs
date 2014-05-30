using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Views.InputMethods;

namespace VirtualKeyboards
{
    [Activity(Label = "VirtualKeyboards", MainLauncher = true)]
    public class MainActivity : Activity
    {
        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Set our view from the "main" layout resource
            SetContentView(Resource.Layout.Main);

            Button closeKeyboardbutton = FindViewById<Button>(Resource.Id.closeKeyboardbutton);
            closeKeyboardbutton.Click += (sender, e) => 
                {
                    InputMethodManager imm = (InputMethodManager)GetSystemService(
                        Context.InputMethodService
                    );
                    imm.HideSoftInputFromWindow(closeKeyboardbutton.WindowToken, HideSoftInputFlags.None);
                };
           
        }
    }
}


