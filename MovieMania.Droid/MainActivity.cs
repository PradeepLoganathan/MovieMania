using System;
using Android.App;
using Android.Content;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using MovieMania.Core;
using System.Threading.Tasks;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;

namespace MovieMania.Droid
{
    [Activity(Label = "MovieMania.Droid",Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        int movieid = 550;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            SetContentView(Resource.Layout.Main);

            
            Button button = FindViewById<Button>(Resource.Id.MyButton);
            TextView Tv = FindViewById<TextView>(Resource.Id.textView1);
            var toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Hello from Appcompat Toolbar";

            


            LoadConfig.Load();

            button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            button.Click += delegate { this.GM(Tv); movieid++; };

            this.GM(Tv);             
        }

        public async void GM(TextView T)
        {
            Movie m = new Movie();
            Movie m1 = await m.GetMovie(movieid);
            T.Text = m1.ToString();

        }
    }
}

