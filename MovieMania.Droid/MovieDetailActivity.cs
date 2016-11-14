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
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.Design.Widget;
using Android.Support.V4.View;
using MovieMania.Core.Client;
using MovieMania.Core.General;
using Android.Graphics.Drawables;

namespace MovieMania.Droid
{
    [Activity(Label = "MovieDetailActivity", Icon = "@drawable/icon")]
    public class MovieDetailActivity : AppCompatActivity
    {
        private int MovieId;
        DrawerLayout drawerlayout;
        private ListView _listView;
        TextView MovieTitle;
        private TextView MovieYear;
        private TextView MovieHomepage;
        private ImageView MovieCover;
        private  MovieManiaClient _client;

        private Movies.Movie movie;
        private TextView MovieComany;
        private TextView MovieTagline;
        private TextView MovieOverview;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);

            SetContentView(Resource.Layout.MovieDetaillayout);

            drawerlayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);
            Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);

            SupportActionBar.SetTitle(Resource.String.app_name);
            // enabling action bar app icon and behaving it as toggle button
            SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);

            //ewPager viewPager = FindViewById<ViewPager>(Resource.Id.tabanim_viewpager);
            
            

            //Load Navigation Drawer view 
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, drawerlayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerlayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            //listView = FindViewById<ListView>(Resource.Id.listview);

            //starting the view from here


            MovieTitle  =  FindViewById<TextView>(Resource.Id.title);
            MovieYear = FindViewById<TextView>(Resource.Id.year);
            MovieHomepage = FindViewById<TextView>(Resource.Id.homepage);
            MovieCover = FindViewById<ImageView>(Resource.Id.cover);
            MovieComany = FindViewById<TextView>(Resource.Id.companies);
            MovieTagline = FindViewById<TextView>(Resource.Id.tagline);
            MovieOverview = FindViewById<TextView>(Resource.Id.overview);
            
            if (this.Intent.Extras.ContainsKey("MovieID"))
                MovieId = (int)this.Intent.Extras.Get("MovieID");

            CreateMovieClient(MovieId);

            // Create your application here
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_home):
                    {
                        Toast.MakeText(this, "Home selected!", ToastLength.Short).Show();
                        break;
                    }
                case (Resource.Id.nav_settings):
                    {
                        Toast.MakeText(this, "Settings selected!", ToastLength.Short).Show();
                        break;
                    }
                case (Resource.Id.nav_info):
                    {
                        this.About();
                        break;
                    }
            }

            drawerlayout.CloseDrawers();

        }

        public void About()
        {
            var uri = Android.Net.Uri.Parse("http://pradeeploganathan.com");
            var i = new Intent(Intent.ActionView, uri);
            StartActivity(i);
        }

        private  Movies.Movie CreateMovieClient(int MovieID)
        {
            

            _client = new MovieManiaClient("");
            try
            {
                if (!_client.HasConfig)
                    _client.GetConfig();

                movie = _client.GetMovieAsync(MovieID).Result;
                MovieTitle.Text = movie.Title;
                MovieYear.Text = movie.ReleaseDate.Value.Year.ToString();
                MovieHomepage.Text = movie.Homepage;
                System.Uri imageuri = GetImageUrl("w185", movie.PosterPath);
                MovieCover.SetImageBitmap(MovieHelper.GetImageBitmapFromUrl(imageuri));
                MovieComany.Text = movie.ProductionCompanies[0].Name;
                MovieTagline.Text = movie.Tagline;
                MovieOverview.Text = movie.Overview;
            }
            catch (Exception ex)
            {
                return null;
            }

            return movie;
        }

        public System.Uri GetImageUrl(string size, string filePath)
        {
            string baseUrl = _client.Config.Images.BaseUrl;
            return new System.Uri(baseUrl + size + filePath);
        }

        private void Each<T>(IEnumerable<T> items, Action<T> action)
        {
            foreach (var item in items)
                action(item);
        }
    }
}