using System;
using Android.Graphics;
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.App;
using Android.Support.V7.Widget;
using System.Net;
using MovieMania.Core.Client;
using MovieMania.Core.General;
using MovieMania.Core.Search;
using System.IO;
using Android.Content;
using LayoutManager = Android.Support.V7.Widget.RecyclerView.LayoutManager;
using AlertDialog = Android.Support.V7.App.AlertDialog;
using SearchView = Android.Support.V7.Widget.SearchView;
using Toolbar = Android.Support.V7.Widget.Toolbar;
using Android.Support.V4.View;
using Android.Net;
using Android.Runtime;

//test
namespace MovieMania.Droid
{
    #region MainActivity
    [Activity(Label = "MovieMania", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerlayout;
        RecyclerView mRecyclerView;
        MovieManiaClient client;
        private SearchView _searchView;
        private ListView _listView;
        

        // Layout manager that lays out each card in the RecyclerView:
        public LayoutManager layoutMgr;
        int MovieNum;

        // Adapter that accesses the data set (a photo album):
        MovieAlbumAdapter mAdapter;
       
        SearchContainer<SearchMovie> results;

        public MainActivity()
        {
           
        }

        private bool IsOnline()
        {
            ConnectivityManager connectivityManager = (ConnectivityManager)GetSystemService(ConnectivityService);
            NetworkInfo activeConnection = connectivityManager.ActiveNetworkInfo;
            return (activeConnection != null) && activeConnection.IsConnected;
        }

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);
            SetContentView(Resource.Layout.Main);
            layoutMgr = null;


            #region Layout Setup
            drawerlayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            //Set up action bar TODO: Work on getting a search bar in the action bar -- Done

           Toolbar toolbar = FindViewById<Toolbar>(Resource.Id.app_bar);
            SetSupportActionBar(toolbar);           
            SupportActionBar.SetTitle(Resource.String.app_name);

            // enabling action bar app icon and behaving it as toggle button
            SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetHomeButtonEnabled(true);


            //Load Navigation Drawer view 
            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;

            // Create ActionBarDrawerToggle button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, drawerlayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerlayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();
            #endregion

            //Load Recycler view as the Main view            
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);
            _listView = FindViewById<ListView>(Resource.Id.listview);

            // Use the built-in linear layout manager:
            layoutMgr = new LinearLayoutManager(this);

            // Plug the layout manager into the RecyclerView. Here it is a linear layout manager since the cards scroll vertically down
            mRecyclerView.SetLayoutManager(layoutMgr);

            //var onScrollListener = new XamarinRecyclerViewOnScrollListener(layoutMgr);


            Random r = new Random();
            int nYear = r.Next(1910, System.DateTime.Now.Year);           
            Snackbar.Make(mRecyclerView, "Popular movies of the year " + nYear.ToString()+ ".", Snackbar.LengthLong).SetAction("OK", action => { }).Show();

            if (!IsOnline())
            {
                var builder = new AlertDialog.Builder(this);

                builder.SetTitle("Hello Dialog")
                 .SetMessage("Is this material design?")
                 .SetPositiveButton("Yes", delegate { Console.WriteLine("Yes"); })
                 .SetNegativeButton("No", delegate { Console.WriteLine("No"); });

                builder.Create().Show();
            }

            client = CreateDiscoverClient(nYear);

            //Create an adapter which takes a collection of movies 
            //and within the adapter set the poster and the movie title
            mAdapter.ItemClick += OnItemClick;
            mAdapter.Client = client;
            mAdapter._MainActivity = this;

            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter);

        }

        private void HandleOkPress(object sender, DialogClickEventArgs e)
        {
            throw new NotImplementedException();
        }

        private void HandleCancelPress(object sender, DialogClickEventArgs e)
        {
            Finish();
        }

        private MovieManiaClient CreateDiscoverClient(int nYear)
        {
            MovieManiaClient _client;

            _client = new MovieManiaClient("4a6dc18b5a3d33c852ec14005d8655d7");
            try
            {
                if (!_client.HasConfig)
                    _client.GetConfig();
            }
            catch (Exception ex)
            {
                
            }
            

            results = _client.DiscoverMoviesAsync().WhereAnyReleaseDateIsInYear(nYear).IncludeAdultMovies(false).Query().Result;
            this.mAdapter = new MovieAlbumAdapter(results);
            this.mAdapter.movies = results;
            return _client;
        }

        private MovieManiaClient CreateSearchClient(string Query)
        {
            MovieManiaClient _client;

            _client = new MovieManiaClient("");
            try
            {
                if (!_client.HasConfig)
                    _client.GetConfig();
            }
            catch (Exception ex)
            {

            }

            results = _client.SearchMovieAsync(Query).Result;
            this.mAdapter.movies.Results.Clear();
            this.mAdapter.movies = results;
            this.mRecyclerView.RemoveAllViews();
            this.mAdapter.NotifyItemRangeRemoved(0,20);
            this.mAdapter.NotifyItemRangeChanged(0, results.TotalResults);
            this.mAdapter.NotifyDataSetChanged();
            mRecyclerView.Invalidate();
            return _client;
        }

        public System.Uri GetImageUrl(string size, string filePath)
        {
            string baseUrl = client.Config.Images.BaseUrl;
            return new System.Uri(baseUrl + size + filePath);
        }

        // Handler for the item click event:
        void OnItemClick(object sender, int position)
        {
            // Display a toast that briefly shows the enumeration of the selected movie
            MovieNum = position + 1;
            Toast.MakeText(this, ((results.Results[position].VoteAverage)/2).ToString(), ToastLength.Short).Show();
        }

        /*void MakeImage()
        {
            /*Bitmap.Config c = new Bitmap.Config();

            Bitmap bmp = Bitmap.CreateBitmap(70, 90, );

            
            using (Bitmap bmp = new Bitmap())
            {
                RectangleF rectf = new RectangleF(70, 90, 90, 50);

                Graphics g = Graphics.FromImage(bmp);

                g.SmoothingMode = SmoothingMode.AntiAlias;
                g.InterpolationMode = InterpolationMode.HighQualityBicubic;
                g.PixelOffsetMode = PixelOffsetMode.HighQuality;
                g.DrawString("yourText", new Font("Tahoma", 8), Brushes.Black, rectf);

                g.Flush();

                image.Image = bmp;
            }
        }*/

       
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

        //define custom title text
        protected override void OnResume()
        {
            SupportActionBar.SetTitle(Resource.String.app_name);
            base.OnResume();
        }


        public override void OnBackPressed()
        {
            if (!_searchView.Iconified)
                _searchView.Iconified = true;
            else
                base.OnBackPressed();
        }

        #region Toolbar
        //add custom icons (Refresh and Share) to toolbar
        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {   
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);

           /* if (menu != null)
            {
                menu.FindItem(Resource.Id.action_search).SetVisible(true);
                menu.FindItem(Resource.Id.refresh).SetVisible(true);
                menu.FindItem(Resource.Id.action_share).SetVisible(true);
                
            }*/

            var item = menu.FindItem(Resource.Id.action_search);
            var test = MenuItemCompat.GetActionView(item);
            _searchView = test.JavaCast<Android.Support.V7.Widget.SearchView>();
            _searchView.Visibility = ViewStates.Visible;
            var visible = _searchView.IsShown;
            _searchView.QueryTextChange += _searchView_QueryTextChange;
            _searchView.QueryTextSubmit += _searchView_QueryTextSubmit;
          


            return base.OnCreateOptionsMenu(menu);
        }

        private void _searchView_QueryTextSubmit(object sender, SearchView.QueryTextSubmitEventArgs e)
        {
            //Toast.MakeText(this, "Query text submitted", ToastLength.Long).Show();
            // StartActivity()
            /*var SearchActivity = new Intent(this, typeof(MovieSearchActivity));
            SearchActivity.PutExtra("MovieName", e.Query);
            StartActivity(SearchActivity);*/
            CreateSearchClient(e.Query);
        }

        private void _searchView_QueryTextChange(object sender, SearchView.QueryTextChangeEventArgs e)
        {
            
        }

        //define action for toolbar icon press
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Resource.Id.action_search:
                    {
                      
                        return true;
                    }
                case Resource.Id.refresh:
                    this.Recreate();
                    return true;
                case Resource.Id.action_share:
                    Share("Movie Information", "Movie information from MovieMania");
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }

        public void Share(string title, string content)
        {

            System.Uri imageuri = GetImageUrl("w185", results.Results[MovieNum].PosterPath);

            if (string.IsNullOrEmpty(title) || string.IsNullOrEmpty(content))
                return;

            Bitmap b = GetImageBitmapFromUrl(imageuri);

            var tempFilename = results.Results[MovieNum].PosterPath.TrimStart('/');
            var sdCardPath = Android.OS.Environment.ExternalStorageDirectory.AbsolutePath;
            //var documentsDirectory = System.Environment.GetFolderPath(System.Environment.SpecialFolder.Personal);
            //string pngFilename = System.IO.Path.Combine(documentsDirectory, imageName + ".png");
            var filePath = System.IO.Path.Combine(sdCardPath, tempFilename);
            using (var os = new FileStream(filePath, FileMode.Create))
            {
                b.Compress(Bitmap.CompressFormat.Png, 100, os);
            }
            b.Dispose();

            var imageUri = Android.Net.Uri.Parse($"file://{sdCardPath}/{tempFilename}");
            var sharingIntent = new Intent();
            sharingIntent.SetAction(Intent.ActionSend);
            sharingIntent.SetType("message/rfc822");
            sharingIntent.PutExtra(Intent.ExtraEmail, new String[] { "" });
            sharingIntent.PutExtra(Intent.ExtraSubject, "Movie information from Movie Mania app");
            sharingIntent.PutExtra(Intent.ExtraText, "Thanks for sharing from The MovieMania App.Download from Playstore https://play.google.com/store/apps/details?id=com.pradeeploganathan.moviemania");
            sharingIntent.AddFlags(ActivityFlags.GrantReadUriPermission);
            sharingIntent.PutExtra(Intent.ExtraStream, imageUri);
            StartActivity(Intent.CreateChooser(sharingIntent, title));
            //File fdelete = new File(filePath);
        }

        public void About()
        {
            var uri = Android.Net.Uri.Parse("http://pradeeploganathan.com");
            var i = new Intent(Intent.ActionView, uri);
            StartActivity(i);
        }

        #endregion

        Bitmap GetImageBitmapFromUrl(System.Uri url)
        {
            Bitmap imageBitmap = null;

            using (var webClient = new WebClient())
            {
                var imageBytes = webClient.DownloadData(url);
                if (imageBytes != null && imageBytes.Length > 0)
                {
                    imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                }
            }

            return imageBitmap;
        }

        
    }
    #endregion

    #region MovieAlbumAdapter

    internal class MovieAlbumAdapter : RecyclerView.Adapter
    {
        // Event handler for item clicks:
        public event EventHandler<int> ItemClick;
        public SearchContainer<SearchMovie> movies;
        private MovieViewHolder vh;
        public Activity _MainActivity;

        public MovieManiaClient Client { get; internal set; }

        public MovieAlbumAdapter(SearchContainer<SearchMovie> discovermovies)
        {
            movies = discovermovies;

        }

        // Create a new photo CardView (invoked by the layout manager): 
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.PhotoCardView, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            vh = new MovieViewHolder(itemView, OnClick);
            return vh;
        }

        // Fill in the contents of the photo card (invoked by the layout manager):
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            MovieViewHolder vh = holder as MovieViewHolder;
            vh.MovieID = movies.Results[position].Id;
            vh._MainActivity = _MainActivity;



            // Set the ImageView and TextView in this ViewHolder's CardView 
            // from this position in the Movie album

            if (DateTime.Today > new DateTime(2015, 11, 16))
            {
                System.Uri imageuri = GetImageUrl("w185", movies.Results[position].PosterPath);
                vh.Image.SetImageBitmap(GetImageBitmapFromUrl(imageuri));
            }
            else
            {
                vh.Image.SetImageBitmap(CreateImage(70, 90, movies.Results[position].Title));
                //vh.Image.SetImageBitmap(textAsBitmap(movies.Results[position].Title, 10));
            }

            vh.Caption.Text = movies.Results[position].Title;
            vh.ratingbar.Rating = (float)((movies.Results[position].VoteAverage)/2);
            
        }

        public System.Uri GetImageUrl(string size, string filePath)
        {
            string baseUrl = Client.Config.Images.BaseUrl;
            return new System.Uri(baseUrl + size + filePath);
        }

        // Return the number of photos available in the photo album:
        public override int ItemCount
        {
            get { return movies.Results.Count; }

            //get { return mPhotoAlbum.NumPhotos; }
            //get { return mDiscover.results.Length; }
        }

        

        // Raise an event when the item-click takes place:
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }

        //Returns a Bitmap object from the url
        private Bitmap GetImageBitmapFromUrl(System.Uri url)
        {
            Bitmap imageBitmap = null;

            try
            {
                using (var webClient = new WebClient())
                {
                    var imageBytes = webClient.DownloadData(url);
                    if (imageBytes != null && imageBytes.Length > 0)
                    {
                        imageBitmap = BitmapFactory.DecodeByteArray(imageBytes, 0, imageBytes.Length);
                    }
                }

                return imageBitmap;
            }
            catch (Exception e)
            {
                //TODO - Add code to return a default bitmap
                return CreateImage(70, 90, "No Poster");
                
            }
        }

        public Bitmap CreateImage(int width, int height, String name)
        {
            Bitmap bitmap = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(bitmap);
            Paint paint2 = new Paint();
            paint2.Color = Color.Black;
            canvas.DrawRect(0F, 0F, (float)width, (float)height, paint2);
            Paint paint = new Paint();
            paint.Color = Color.White;
            paint.TextSize = 12;
            paint.TextScaleX = 1;
            canvas.DrawText(name, 10, 15, paint);
            return bitmap;
        }

       public Bitmap textAsBitmap(String text, float textSize)
        {
            Paint paint = new Paint(PaintFlags.AntiAlias);
            paint.TextSize = textSize;
            paint.Color = Color.Black;
            paint.TextAlign = Paint.Align.Left;
            float baseline = -paint.Ascent(); // ascent() is negative
            int width = (int)(paint.MeasureText(text) + 0.5f); // round
            int height = (int)(baseline + paint.Descent() + 0.5f);
            Bitmap image = Bitmap.CreateBitmap(width, height, Bitmap.Config.Argb8888);
            Canvas canvas = new Canvas(image);
            canvas.DrawText(text, 0, baseline, paint);
            return image;
        }




    }

    #endregion

    #region MovieViewHolder
    internal class MovieViewHolder : RecyclerView.ViewHolder
    {
        //private View.IOnClickListener onclicklistener;

        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }
        public RatingBar ratingbar { get; private set; }
        public Activity _MainActivity;
        public int MovieID;



        // Get references to the views defined in the CardView layout.
        public MovieViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);
            ratingbar = itemView.FindViewById<RatingBar>(Resource.Id.ratingbar);
            ratingbar.Focusable = false;
            ratingbar.StepSize = 0.01F;
            
            // Detect user clicks on the item view and report which item
            // was clicked (by position) to the listener:
            //itemView.Click += (sender, e) => listener(base.Position);
            itemView.Click += ItemView_Click;
            Image.Click += Image_Click;
        }

        private void Image_Click(object sender, EventArgs e)
        {
            Intent intent = new Intent(_MainActivity, typeof(MovieDetailActivity));
            intent.PutExtra("MovieID", MovieID);
            _MainActivity.StartActivity(intent);
        }

        private void ItemView_Click(object sender, EventArgs e)
        {
            
        }
    }
    #endregion

    #region XamarinRecyclerViewOnScrollListener
    public class XamarinRecyclerViewOnScrollListener : RecyclerView.OnScrollListener
    {
        public delegate void LoadMoreEventHandler(object sender, EventArgs e);
        public event LoadMoreEventHandler LoadMoreEvent;
        private LayoutManager LayoutManager;
        
        public XamarinRecyclerViewOnScrollListener(LayoutManager layoutManager)
        {
            LayoutManager = layoutManager;
        }
        public override void OnScrolled(RecyclerView recyclerView, int dx, int dy)
        {
            base.OnScrolled(recyclerView, dx, dy);
            var visibleItemCount = recyclerView.ChildCount;
            var totalItemCount = recyclerView.GetAdapter().ItemCount;
           // var pastVisiblesItems = LayoutManager.FindFirstVisibleItemPosition();

            /*if ((visibleItemCount + pastVisiblesItems) >= totalItemCount)
            {
                LoadMoreEvent(this, null);
            }*/
        }
    }
    #endregion
}
