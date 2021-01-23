using System;
using System.IO;
using Android.App;
using Android.Content;
using Android.Graphics;
using Android.OS;
using Android.Runtime;
using Android.Support.Design.Widget;
using Android.Support.V4.App;
using Android.Support.V7.App;
using Android.Views;
using Android.Widget;
using Environment = System.Environment;

namespace StackQA1
{
    [Activity(Label = "@string/app_name", Theme = "@style/AppTheme.NoActionBar", MainLauncher = true)]
    public class MainActivity : AppCompatActivity
    {
        private Bitmap bitmap;
        private int requestId;

        protected override void OnCreate(Bundle savedInstanceState)
        {
            base.OnCreate(savedInstanceState);
            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            SetContentView(Resource.Layout.activity_main);

            Android.Support.V7.Widget.Toolbar toolbar = FindViewById<Android.Support.V7.Widget.Toolbar>(Resource.Id.toolbar);
            SetSupportActionBar(toolbar);

            FloatingActionButton fab = FindViewById<FloatingActionButton>(Resource.Id.fab);
            fab.Click += FabOnClick;
        }

        public override bool OnCreateOptionsMenu(IMenu menu)
        {
            MenuInflater.Inflate(Resource.Menu.menu_main, menu);
            return true;
        }

        public override bool OnOptionsItemSelected(IMenuItem item)
        {
            int id = item.ItemId;
            if (id == Resource.Id.action_settings)
            {
                return true;
            }

            return base.OnOptionsItemSelected(item);
        }

        private void FabOnClick(object sender, EventArgs eventArgs)
        {
            try
            {
                View view = (View)sender;
                Snackbar.Make(view, "Replace with your own action", Snackbar.LengthLong)
                    .SetAction("Action", (Android.Views.View.IOnClickListener)null).Show();

                CouldNotFindPath();

            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }

        }

        private void CouldNotFindPath()
        {
            //https://stackoverflow.com/questions/65743271/xamarin-could-not-find-a-part-of-the-path/65749505#65749505
            bitmap = Bitmap.CreateBitmap(100, 100, Bitmap.Config.Alpha8);

            var folderPath = Environment.GetFolderPath(Environment.SpecialFolder.Personal);
            Directory.CreateDirectory(System.IO.Path.Combine(folderPath, "Pictures"));
            var filePath = System.IO.Path.Combine(folderPath, "Pictures/profile_picture.png");

            //using (StreamWriter w = File.AppendText(filePath))
            //{
            //    w.WriteLine("some text");
            //}

            var stream = new FileStream(filePath, FileMode.Create);
            //new FileStream()
            bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
            stream.Close();
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }


        public void FullScreenNotification()
        {
            //var intent = new Intent(Application.Context, typeof(MainActivity));
            //intent.AddFlags(ActivityFlags.NewTask);
            //Application.Context.StartActivity(intent);
            //PendingIntent fullScreenIntent = PendingIntent.GetActivity(Application.Context, requestId++, intent, PendingIntentFlags.CancelCurrent);

            //var builder = new NotificationCompat.Builder(Application.Context, channelID)
            //                .SetAutoCancel(false)
            //                .SetOngoing(true)
            //                .SetVisibility(NotificationCompat.VisibilityPublic)
            //                .SetSmallIcon(Resource.Drawable.applogo)
            //                .SetFullScreenIntent(fullScreenIntent, true);
        }

    }
}
