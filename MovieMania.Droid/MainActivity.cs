
using Android.Widget;
using Android.OS;
using Android.Support.Design.Widget;
using Android.Support.V4.Widget;
using Android.Support.V7.App;
using Android.Views;
using Android.App;
using Android;
using MovieMania.Droid;
using Android.Support.V7.Widget;
using LayoutManager = Android.Support.V7.Widget.RecyclerView.LayoutManager;
using System;

namespace MovieMania.Droid
{
    [Activity(Label = "MovieMania", MainLauncher = true, Icon = "@drawable/icon")]
    public class MainActivity : AppCompatActivity
    {
        DrawerLayout drawerlayout;
        RecyclerView mRecyclerView;
        // Layout manager that lays out each card in the RecyclerView:
        public LayoutManager layoutMgr;

        // Adapter that accesses the data set (a photo album):
        PhotoAlbumAdapter mAdapter;

        // Photo album that is managed by the adapter:
        PhotoAlbum mPhotoAlbum;

        protected override void OnCreate(Bundle bundle)
        {
            base.OnCreate(bundle);

            // Instantiate the photo album:
            mPhotoAlbum = new PhotoAlbum();


            SetContentView(Droid.Resource.Layout.Main);
            layoutMgr = null;

           

            drawerlayout = FindViewById<DrawerLayout>(Resource.Id.drawer_layout);

            var toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.app_bar);

            SetSupportActionBar(toolbar);

            SupportActionBar.SetTitle(Resource.String.app_name);
            SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(true);
            SupportActionBar.SetDefaultDisplayHomeAsUpEnabled(true);

            var navigationView = FindViewById<NavigationView>(Resource.Id.nav_view);
            navigationView.NavigationItemSelected += NavigationView_NavigationItemSelected;
            // Create ActionBarDrawerToggle button and add it to the toolbar
            var drawerToggle = new ActionBarDrawerToggle(this, drawerlayout, toolbar, Resource.String.open_drawer, Resource.String.close_drawer);
            drawerlayout.SetDrawerListener(drawerToggle);
            drawerToggle.SyncState();

            //load default home screen
            /* var ft = FragmentManager.BeginTransaction();
             ft.AddToBackStack(null);
             ft.Add(Resource.Id.HomeFrameLayout, new HomeFragment());
             ft.Commit();*/


            /*******************************/

            // RecyclerView instance that displays the photo album:
            
            mRecyclerView = FindViewById<RecyclerView>(Resource.Id.recyclerView);

            // Use the built-in linear layout manager:
            layoutMgr = new LinearLayoutManager(this);

            // Plug the layout manager into the RecyclerView:
            mRecyclerView.SetLayoutManager(layoutMgr);


            mAdapter = new PhotoAlbumAdapter(mPhotoAlbum);

            mAdapter.ItemClick += OnItemClick;

            // Plug the adapter into the RecyclerView:
            mRecyclerView.SetAdapter(mAdapter);



        }

        // Handler for the item click event:
        void OnItemClick(object sender, int position)
        {
            // Display a toast that briefly shows the enumeration of the selected photo:
            int photoNum = position + 1;
            Toast.MakeText(this, "This is photo number " + photoNum, ToastLength.Short).Show();
        }

        private void NavigationView_NavigationItemSelected(object sender, NavigationView.NavigationItemSelectedEventArgs e)
        {
            switch (e.MenuItem.ItemId)
            {
                case (Resource.Id.nav_home):
                    Toast.MakeText(this, "Home selected!", ToastLength.Short).Show();
                    break;
                case (Resource.Id.nav_messages):
                    Toast.MakeText(this, "Message selected!", ToastLength.Short).Show();
                    break;
                case (Resource.Id.nav_friends):
                    // React on 'Friends' selection
                    break;
            }

            drawerlayout.CloseDrawers();

        }

        //define custom title text
        protected override void OnResume()
        {
            SupportActionBar.SetTitle(Resource.String.app_name);
            base.OnResume();
        }

        //add custom icon to tolbar
        public override bool OnCreateOptionsMenu(Android.Views.IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.action_menu, menu);
            if (menu != null)
            {
                menu.FindItem(Resource.Id.action_refresh).SetVisible(true);
                menu.FindItem(Resource.Id.action_attach).SetVisible(false);
            }
            return base.OnCreateOptionsMenu(menu);
        }
        //define action for tolbar icon press
        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            switch (item.ItemId)
            {
                case Android.Resource.Id.Home:
                    //this.Activity.Finish();
                    return true;
                case Resource.Id.action_attach:
                    //FnAttachImage();
                    return true;
                default:
                    return base.OnOptionsItemSelected(item);
            }
        }
        //to avoid direct app exit on backpreesed and to show fragment from stack
        public override void OnBackPressed()
        {
            if (FragmentManager.BackStackEntryCount != 0)
            {
                FragmentManager.PopBackStack();// fragmentManager.popBackStack();
            }
            else
            {
                base.OnBackPressed();
            }
        }
    }

    internal class PhotoAlbumAdapter : RecyclerView.Adapter
    {
        // Event handler for item clicks:
        public event EventHandler<int> ItemClick;

        // Underlying data set (a photo album):
        public PhotoAlbum mPhotoAlbum;

        // Load the adapter with the data set (photo album) at construction time:
        public PhotoAlbumAdapter(PhotoAlbum photoAlbum)
        {
            mPhotoAlbum = photoAlbum;
        }

        // Create a new photo CardView (invoked by the layout manager): 
        public override RecyclerView.ViewHolder OnCreateViewHolder(ViewGroup parent, int viewType)
        {
            // Inflate the CardView for the photo:
            View itemView = LayoutInflater.From(parent.Context).
                        Inflate(Resource.Layout.PhotoCardView, parent, false);

            // Create a ViewHolder to find and hold these view references, and 
            // register OnClick with the view holder:
            PhotoViewHolder vh = new PhotoViewHolder(itemView, OnClick);
            return vh;
        }

        // Fill in the contents of the photo card (invoked by the layout manager):
        public override void OnBindViewHolder(RecyclerView.ViewHolder holder, int position)
        {
            PhotoViewHolder vh = holder as PhotoViewHolder;

            // Set the ImageView and TextView in this ViewHolder's CardView 
            // from this position in the photo album:
            vh.Image.SetImageResource(mPhotoAlbum[position].PhotoID);
            vh.Caption.Text = mPhotoAlbum[position].Caption;
        }

        // Return the number of photos available in the photo album:
        public override int ItemCount
        {
            get { return mPhotoAlbum.NumPhotos; }
        }

        // Raise an event when the item-click takes place:
        void OnClick(int position)
        {
            if (ItemClick != null)
                ItemClick(this, position);
        }
    }

    internal class PhotoAlbum
    {
        // Built-in photo collection - this could be replaced with
        // a photo database:

        static Photo[] mBuiltInPhotos = {
            new Photo { mPhotoID = Resource.Drawable.buckingham_guards,
                        mCaption = "Buckingham Palace" },
            new Photo { mPhotoID = Resource.Drawable.la_tour_eiffel,
                        mCaption = "The Eiffel Tower" },
            new Photo { mPhotoID = Resource.Drawable.louvre_1,
                        mCaption = "The Louvre" },
            new Photo { mPhotoID = Resource.Drawable.before_mobile_phones,
                        mCaption = "Before mobile phones" },
            new Photo { mPhotoID = Resource.Drawable.big_ben_1,
                        mCaption = "Big Ben skyline" },
            new Photo { mPhotoID = Resource.Drawable.big_ben_2,
                        mCaption = "Big Ben from below" },
            new Photo { mPhotoID = Resource.Drawable.london_eye,
                        mCaption = "The London Eye" },
            new Photo { mPhotoID = Resource.Drawable.eurostar,
                        mCaption = "Eurostar Train" },
            new Photo { mPhotoID = Resource.Drawable.arc_de_triomphe,
                        mCaption = "Arc de Triomphe" },
            new Photo { mPhotoID = Resource.Drawable.louvre_2,
                        mCaption = "Inside the Louvre" },
            new Photo { mPhotoID = Resource.Drawable.versailles_fountains,
                        mCaption = "Versailles fountains" },
            new Photo { mPhotoID = Resource.Drawable.modest_accomodations,
                        mCaption = "Modest accomodations" },
            new Photo { mPhotoID = Resource.Drawable.notre_dame,
                        mCaption = "Notre Dame" },
            new Photo { mPhotoID = Resource.Drawable.inside_notre_dame,
                        mCaption = "Inside Notre Dame" },
            new Photo { mPhotoID = Resource.Drawable.seine_river,
                        mCaption = "The Seine" },
            new Photo { mPhotoID = Resource.Drawable.rue_cler,
                        mCaption = "Rue Cler" },
            new Photo { mPhotoID = Resource.Drawable.champ_elysees,
                        mCaption = "The Avenue des Champs-Elysees" },
            new Photo { mPhotoID = Resource.Drawable.seine_barge,
                        mCaption = "Seine barge" },
            new Photo { mPhotoID = Resource.Drawable.versailles_gates,
                        mCaption = "Gates of Versailles" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_castle_2,
                        mCaption = "Edinburgh Castle" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_castle_1,
                        mCaption = "Edinburgh Castle up close" },
            new Photo { mPhotoID = Resource.Drawable.old_meets_new,
                        mCaption = "Old meets new" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_from_on_high,
                        mCaption = "Edinburgh from on high" },
            new Photo { mPhotoID = Resource.Drawable.edinburgh_station,
                        mCaption = "Edinburgh station" },
            new Photo { mPhotoID = Resource.Drawable.scott_monument,
                        mCaption = "Scott Monument" },
            new Photo { mPhotoID = Resource.Drawable.view_from_holyrood_park,
                        mCaption = "View from Holyrood Park" },
            new Photo { mPhotoID = Resource.Drawable.tower_of_london,
                        mCaption = "Outside the Tower of London" },
            new Photo { mPhotoID = Resource.Drawable.tower_visitors,
                        mCaption = "Tower of London visitors" },
            new Photo { mPhotoID = Resource.Drawable.one_o_clock_gun,
                        mCaption = "One O'Clock Gun" },
            new Photo { mPhotoID = Resource.Drawable.victoria_albert,
                        mCaption = "Victoria and Albert Museum" },
            new Photo { mPhotoID = Resource.Drawable.royal_mile,
                        mCaption = "The Royal Mile" },
            new Photo { mPhotoID = Resource.Drawable.museum_and_castle,
                        mCaption = "Edinburgh Museum and Castle" },
            new Photo { mPhotoID = Resource.Drawable.portcullis_gate,
                        mCaption = "Portcullis Gate" },
            new Photo { mPhotoID = Resource.Drawable.to_notre_dame,
                        mCaption = "Left or right?" },
            new Photo { mPhotoID = Resource.Drawable.pompidou_centre,
                        mCaption = "Pompidou Centre" },
            new Photo { mPhotoID = Resource.Drawable.heres_lookin_at_ya,
                        mCaption = "Here's Lookin' at Ya!" },
            };

        // Array of photos that make up the album:
        private Photo[] mPhotos;

        // Random number generator for shuffling the photos:
        Random mRandom;

        // Create an instance copy of the built-in photo list and
        // create the random number generator:
        public PhotoAlbum()
        {
            mPhotos = mBuiltInPhotos;
            mRandom = new Random();
        }

        // Return the number of photos in the photo album:
        public int NumPhotos
        {
            get { return mPhotos.Length; }
        }

        // Indexer (read only) for accessing a photo:
        public Photo this[int i]
        {
            get { return mPhotos[i]; }
        }

        // Pick a random photo and swap it with the top:
        public int RandomSwap()
        {
            // Save the photo at the top:
            Photo tmpPhoto = mPhotos[0];

            // Generate a next random index between 1 and 
            // Length (noninclusive):
            int rnd = mRandom.Next(1, mPhotos.Length);

            // Exchange top photo with randomly-chosen photo:
            mPhotos[0] = mPhotos[rnd];
            mPhotos[rnd] = tmpPhoto;

            // Return the index of which photo was swapped with the top:
            return rnd;
        }

        // Shuffle the order of the photos:
        public void Shuffle()
        {
            // Use the Fisher-Yates shuffle algorithm:
            for (int idx = 0; idx < mPhotos.Length; ++idx)
            {
                // Save the photo at idx:
                Photo tmpPhoto = mPhotos[idx];

                // Generate a next random index between idx (inclusive) and 
                // Length (noninclusive):
                int rnd = mRandom.Next(idx, mPhotos.Length);

                // Exchange photo at idx with randomly-chosen (later) photo:
                mPhotos[idx] = mPhotos[rnd];
                mPhotos[rnd] = tmpPhoto;
            }
        }
    }

    internal class Photo
    {
        // Photo ID for this photo:
        public int mPhotoID;

        // Caption text for this photo:
        public string mCaption;

        // Return the ID of the photo:
        public int PhotoID
        {
            get { return mPhotoID; }
        }

        // Return the Caption of the photo:
        public string Caption
        {
            get { return mCaption; }
        }
    }

    internal class PhotoViewHolder : RecyclerView.ViewHolder
    {
        public ImageView Image { get; private set; }
        public TextView Caption { get; private set; }

        // Get references to the views defined in the CardView layout.
        public PhotoViewHolder(View itemView, Action<int> listener)
            : base(itemView)
        {
            // Locate and cache view references:
            Image = itemView.FindViewById<ImageView>(Resource.Id.imageView);
            Caption = itemView.FindViewById<TextView>(Resource.Id.textView);

            // Detect user clicks on the item view and report which item
            // was clicked (by position) to the listener:
            itemView.Click += (sender, e) => listener(base.Position);
        }
    }
}



