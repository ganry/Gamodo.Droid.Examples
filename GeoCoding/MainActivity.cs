using System;

using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Locations;
using System.Collections.Generic;
using Android.Util;

namespace GeoCoding
{
    [Activity(Label = "GeoCoding", MainLauncher = true)]
    public class MainActivity : Activity, ILocationListener
    {
        private Spinner States;
        private Button button;
        private EditText etAddress;
        private EditText etCity;
        private EditText etZipCode;
        private AutoCompleteTextView actvCountry;
        private LocationManager lm;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            try
            {
                button = FindViewById<Button>(Resource.Id.Submit);
                button.Click += new EventHandler(button_Click);
                States = FindViewById<Spinner>(Resource.Id.State);

                var fAdapter = ArrayAdapter.CreateFromResource(this,
                    Resource.Array.states,
                    Android.Resource.Layout.SimpleSpinnerDropDownItem);
                int spinner_dd_item = Android.Resource.
                    Layout.SimpleSpinnerDropDownItem;
                fAdapter.SetDropDownViewResource(spinner_dd_item);
                States.Adapter = fAdapter;

                etAddress = FindViewById<EditText>(Resource.Id.Address);
                etCity = FindViewById<EditText>(Resource.Id.City);
                etZipCode = FindViewById<EditText>(Resource.Id.Zip);

            }
            catch (System.Exception sysExc)
            {
                Toast.MakeText(this, sysExc.Message, ToastLength.Short).Show();
            }
        }

        protected override void OnPause ()
        {
            base.OnPause ();
            lm.RemoveUpdates (this);
        }


        protected override void OnResume ()
        {
            base.OnResume ();
            Criteria locationCriteria = new Criteria();

            locationCriteria.Accuracy = Accuracy.Coarse;
            locationCriteria.PowerRequirement = Power.Medium;

            string locationProvider = lm.GetBestProvider(locationCriteria, true);

            if(locationProvider != null)
                {
                    lm.RequestLocationUpdates (locationProvider, 2000, 1, this);
                } 
            else 
                {
                    Log.Info("Location Error:", "No location providers available");
                }
        }

        void button_Click(object sender, EventArgs e)
        {
            EditText ev = FindViewById<EditText>(Resource.Id.Name);
            string message = "Your values will now be processed.";
            Toast.MakeText(this, message, ToastLength.Short).Show();
        }

        void GetAddress(double Lat, double Lon)
        {
            try
            {
                IList<Address> al;
                Geocoder geoc = new Geocoder(this, Java.Util.Locale.Default);
                al = geoc.GetFromLocation(Lat, Lon, 10);
                if ((al != null) && (al.Count > 0))
                    {
                        var firstAddress = al[0];
                        var addressLine0 = firstAddress.GetAddressLine(0);
                        var City = firstAddress.Locality;
                        var zip = firstAddress.PostalCode;

                        Log.Info("Location:", "FristAdress: "+firstAddress);
                        Log.Info("Location:", "addressLine0: "+addressLine0);
                        Log.Info("Location:", "City: "+City);
                        Log.Info("Location:", "zip: "+zip);


                        if (!String.IsNullOrEmpty(City))
                            {
                                RunOnUiThread(() => etCity.Text = City);
                            }
                        else
                            {
                                RunOnUiThread(() => etCity.Text = String.Empty);
                            }
                        if (!String.IsNullOrEmpty(zip))
                            {
                                RunOnUiThread(() => etZipCode.Text = zip);
                            }
                        else
                            {
                                RunOnUiThread(() => etZipCode.Text = String.Empty);
                            }
                        lm.RemoveUpdates(this);
                    }
            }
            finally { }
        }
            
        public void OnLocationChanged(Location location)
        {
            GetAddress(location.Latitude, location.Longitude);
        }

        public void OnProviderDisabled(string provider) { }
        public void OnProviderEnabled(string provider) { }
        public void OnStatusChanged(string provider, 
            Availability status,
            Bundle extras) { }
    }
}

