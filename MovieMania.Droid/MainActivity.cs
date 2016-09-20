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
    [Activity(Label = "@string/app_name",Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        int count = 1;
        int movieid = 550;
        internal Toolbar toolbar;
        internal Sample[] mSamples;
        internal GridView mGridView;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            
            SetContentView(Resource.Layout.Main);

            
            //Button button = FindViewById<Button>(Resource.Id.MyButton);
            //TextView Tv = FindViewById<TextView>(Resource.Id.textView1);

            toolbar = FindViewById<Toolbar>(Resource.Id.toolbar);

            
            mSamples = new Sample[] {
                new Sample (Resource.String.navigationdraweractivity_title,
                    Resource.String.navigationdraweractivity_description,
                    this,
                    typeof(NavigationDrawerActivity)),
            };


            SetSupportActionBar(toolbar);
            SupportActionBar.Title = "Movie Mania";

            


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

    internal class Sample : Java.Lang.Object
    {
        internal int titleResId;
        internal int descriptionResId;
        internal Intent intent;

        public Sample(int titleResId, int descriptionResId, Intent intent)
        {
            Initialize(titleResId, descriptionResId, intent);
        }

        public Sample(int titleResId, int descriptionResId, Context c, Type t)
        {
            Initialize(titleResId, descriptionResId, new Intent(c, t));
        }

        private void Initialize(int titleResId, int descriptionResId, Intent intent)
        {
            this.intent = intent;
            this.titleResId = titleResId;
            this.descriptionResId = descriptionResId;
        }
    }

    /// <summary>
    /// 
    /// </summary>
    internal class SampleAdapter : BaseAdapter
    {
        private MainActivity owner;

        public SampleAdapter(MainActivity owner) : base()
        {
            this.owner = owner;
        }

        public override int Count
        {
            get
            {
                return owner.mSamples.Length;
            }
        }


        public override Java.Lang.Object GetItem(int position)
        {
            return owner.mSamples[position];
        }

        public override long GetItemId(int position)
        {
            return (long)owner.mSamples[position].GetHashCode();
        }

        public override View GetView(int position, View convertView, ViewGroup container)
        {
            if (convertView == null)
            {
                convertView = owner.LayoutInflater.Inflate(Resource.Layout.sample_dashboard_item, container, false);
            }
            convertView.FindViewById<TextView>(Android.Resource.Id.Text1).SetText(owner.mSamples[position].titleResId);
            convertView.FindViewById<TextView>(Android.Resource.Id.Text2).SetText(owner.mSamples[position].descriptionResId);
            return convertView;
        }
    }
}

