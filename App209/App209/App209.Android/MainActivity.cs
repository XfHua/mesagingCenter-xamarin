using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using Android.Content;
using Xamarin.Forms;

namespace App209.Droid
{
    [Activity(Label = "App209", Icon = "@mipmap/icon", Theme = "@style/MainTheme", MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation)]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {

        BarcodeModel barcodeModel;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());


            Handler h = new Handler();
            Action myAction = () =>
            {
                DisplayResult(new Intent());
            };

            h.PostDelayed(myAction, 5000);
        }
        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public void DisplayResult(Intent intent)
        {
            //  Output the scanned barcode to ViewModel
            barcodeModel.decodedData = intent.GetStringExtra(Resources.GetString(Resource.String.datawedge_intent_key_data));
            barcodeModel.decodedData = "test";

            MessagingCenter.Send<object, BarcodeModel>(new object(), "barCodeScanned", barcodeModel);
        }
    }
}