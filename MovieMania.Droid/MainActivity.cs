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
        Toolbar toolbar;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            SetContentView(Resource.Layout.Main);

            
            //Button button = FindViewById<Button>(Resource.Id.MyButton);
            //TextView Tv = FindViewById<TextView>(Resource.Id.textView1);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Hello from Toolbar";

            


            LoadConfig.Load();

            //button.Click += delegate { button.Text = string.Format("{0} clicks!", count++); };
            //button.Click += delegate { this.GM(Tv); movieid++; };

            //this.GM(Tv);             
        }

        public async void GM(TextView T)
        {
            Movie m = new Movie();
            Movie m1 = await m.GetMovie(movieid);
            T.Text = m1.ToString();

        }

        /// <Docs>The options menu in which you place your items.</Docs>
		/// <returns>To be added.</returns>
		/// <summary>
		/// This is the menu for the Toolbar/Action Bar to use
		/// </summary>
		/// <param name="menu">Menu.</param>
		public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.home, menu);
            return base.OnCreateOptionsMenu(menu);
        }
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            Toast.MakeText(this, "Top ActionBar pressed: " + item.TitleFormatted, ToastLength.Short).Show();
            return base.OnOptionsItemSelected(item);
        }
    }
}

