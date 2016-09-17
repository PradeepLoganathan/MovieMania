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

namespace MovieMania.Droid
{
    [Activity(Label = "SplashActivity", MainLauncher =true, Theme = "@style/MyTheme.Splash", NoHistory =true, Icon ="@drawable/icon")]
    public class SplashActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            System.Threading.Thread.Sleep(1000);
            StartActivity(new Intent(Application.Context, typeof(MainActivity)));


            // Create your application here
        }
    }
}