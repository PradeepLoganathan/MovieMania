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
using Java.Lang;
using Android.Graphics;
using System.Net;
using System.Threading.Tasks;
using System.Collections;

namespace MovieMania.Droid
{
    [Activity(Label = "MovieGridViewActivity")]
    public class MovieGridViewActivity : Activity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            SetContentView(Resource.Layout.Main);
            
            //Find the gridview
            var gridView = FindViewById<GridView>(Resource.Id.gridview);

            //create the Image adapter and set the gridview adapter to the image adapter
            //gridView.Adapter = new ImageAdapter(this, Resource.Id.gridview,

            //Create a delegate to handle the click event of the grid.
            gridView.ItemClick += GridView_ItemClick;

            // Create your application here
        }

        private void GridView_ItemClick(object sender, AdapterView.ItemClickEventArgs e)
        {
            Toast.MakeText(this, (e.Position + 1).ToString(), ToastLength.Short);
        }

    }

    public class ImageAdapter : ArrayAdapter
    {
        private Context context;
        private int layoutresourceid;
        private ArrayList data = new ArrayList();

        public ImageAdapter(Context context, int layoutresourceid, ArrayList data) :base(context,layoutresourceid, data)
        {

            this.layoutresourceid = layoutresourceid;
            this.context = context;
            this.data = data;

        }          
        
      
        public override View GetView(int position, View convertView, ViewGroup parent)
        {

            ImageView imageView;

            if (convertView == null)
            {
                // if it's not recycled, initialize some attributes
                imageView = new ImageView(context);
                imageView.LayoutParameters = new AbsListView.LayoutParams(85, 85);
                imageView.SetScaleType(ImageView.ScaleType.CenterCrop);
                imageView.SetPadding(8, 8, 8, 8);
            }
            else
            {
                imageView = (ImageView)convertView;
            }
            
            return imageView;
        }

        /*View row = convertView;
        ViewHolder holder = null;

        if (row == null)
        {
            LayoutInflater inflater = ((Activity)Context).LayoutInflater;
            row = inflater.Inflate(layoutresourceid, parent, false);
            holder = new ViewHolder();
            holder.ImageTitle = (TextView)row.FindViewById(Resource.Id.text);
            holder.Image = (ImageView)row.FindViewById(Resource.Id.image);
        }
        else
        {
            //holder = (ViewHolder)row.GetTag();
        }

        ImageItem item = (ImageItem)data[position];
        holder.Image.SetImageBitmap(item.image);
        holder.ImageTitle.Text = item.title;
        return row;*/


    


        private async Task<Bitmap> GetBitMapfromUrl(string URL)
        {
            //try
            //{
            //    using (WebClient webclient = new WebClient())
            //    {
            //        byte[] bytes = await webclient.DownloadDataTaskAsync(URL);
            //        if (bytes != null && bytes.Length > 0)
            //            return BitmapFactory.DecodeByteArray(bytes, 0, bytes.Length);
            //    }
            //}
            //catch (TaskCanceledException Te)
            //{

            //}
            //catch (System.Exception e)
            //{

            //}


            return null;
        }


    }

    public class ViewHolder
    {
        public TextView ImageTitle { get; set; }
       
        public ImageView Image { get; set; }
    }

    public class ImageItem
    {
        public int id { get; set; }
        public Bitmap image { get; set; }
        public string title { get; set; }

        public ImageItem(int id, Bitmap Image, string Title)
        {
            this.id = id;
            this.image = Image;
            this.title = Title;
        }

    }
}

