using System;

using Android.App;
using Android.Content.PM;
using Android.Runtime;
using Android.Views;
using Android.Widget;
using Android.OS;
using System.Threading.Tasks;
using Xamarin.Forms;
using Android.Graphics;
using Android.Provider;
using System.IO;

namespace StackQA2XF.Droid
{
    [Activity(Label = "StackQA2XF", Icon = "@mipmap/icon", Theme = "@style/MainTheme", LaunchMode = LaunchMode.Multiple, MainLauncher = true, ConfigurationChanges = ConfigChanges.ScreenSize | ConfigChanges.Orientation | ConfigChanges.UiMode | ConfigChanges.ScreenLayout | ConfigChanges.SmallestScreenSize)]
    [IntentFilter(new string[] { Android.Content.Intent.ActionSend }, Categories = new string[] { Android.Content.Intent.CategoryDefault },    DataMimeType = "image/*")]
    [IntentFilter(new string[] { Android.Content.Intent.ActionSendMultiple }, Categories = new string[] { Android.Content.Intent.CategoryDefault },    DataMimeType = "image/*")]
    public class MainActivity : global::Xamarin.Forms.Platform.Android.FormsAppCompatActivity
    {
        protected override void OnCreate(Bundle savedInstanceState)
        {
            TabLayoutResource = Resource.Layout.Tabbar;
            ToolbarResource = Resource.Layout.Toolbar;

            base.OnCreate(savedInstanceState);

            Xamarin.Essentials.Platform.Init(this, savedInstanceState);
            global::Xamarin.Forms.Forms.Init(this, savedInstanceState);
            LoadApplication(new App());

            DynamicTrigger();

            if (Intent.Action == "android.intent.action.SEND")
            {
                Android.Net.Uri imageUri = (Android.Net.Uri)Intent.GetParcelableExtra(Android.Content.Intent.ExtraStream);
                var stream = ContentResolver.OpenInputStream(imageUri);
                MessagingCenter.Send(Xamarin.Forms.Application.Current, "ImageSent", stream);

                #region "cmd"
                //Bitmap bitmap;
                //byte[] bitmapData = null;
                //if (Build.VERSION.SdkInt >= BuildVersionCodes.Q)
                //{
                //    var source = ImageDecoder.CreateSource(this.ContentResolver, Android.Net.Uri.Parse(imageUri));
                //    bitmap = ImageDecoder.DecodeBitmap(source);
                //}
                //else
                //{
                //    #pragma warning disable CS0618
                //    bitmap = MediaStore.Images.Media.GetBitmap(this.ContentResolver, imageUri);
                //    #pragma warning restore CS0618
                //}
                //using (var stream1 = new MemoryStream())
                //{
                //    bitmap.Compress(Bitmap.CompressFormat.Png, 100, stream);
                //    bitmapData = stream1.ToArray();
                //}
                #endregion
            }
        }

        public override void OnRequestPermissionsResult(int requestCode, string[] permissions, [GeneratedEnum] Android.Content.PM.Permission[] grantResults)
        {
            Xamarin.Essentials.Platform.OnRequestPermissionsResult(requestCode, permissions, grantResults);

            base.OnRequestPermissionsResult(requestCode, permissions, grantResults);
        }

        public async Task DynamicTrigger()
        {
            await Task.Delay(2000);
            MessagingCenter.Send(Xamarin.Forms.Application.Current, "StringTest", "Lable's text set from trigger of 2 seconds");
        }
    }
}