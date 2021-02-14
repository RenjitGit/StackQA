using System;
using System.Threading.Tasks;
using Android.App;
using Android.Content;
using Android.OS;
using Android.Support.V4.App;
using StackQAXFNotification.Droid.Service;
using StackQAXFNotification.Interface;
using Xamarin.Forms;
using static Android.OS.PowerManager;

[assembly: Dependency(typeof(NotificationHandler))]
namespace StackQAXFNotification.Droid.Service
{
    public class NotificationHandler : INotificationHandler
    {
        private NotificationManager _nativeNotificationManager;
        private string _channelID = string.Empty;
        private int _requestCode = 0;

        public void CreateNotification(string title, string message)
        {
            CreateNotificationChannel();
            var builder = CreateNotificationBuilder(title, message);
            _nativeNotificationManager.Notify(1, builder.Build());
            //WakeUpScreenAsync();
        }

        private NotificationCompat.Builder CreateNotificationBuilder(string title, string message)
        {
            PendingIntent fullScreenIntent = GetIncomingCallPendingIntent();
            var builder = new NotificationCompat.Builder(Android.App.Application.Context, _channelID)
                      .SetContentTitle(title)
                      .SetContentText(message)
                      .SetAutoCancel(false)
                      .SetOngoing(true)
                      .SetVisibility(NotificationCompat.VisibilityPublic)
                      .SetSmallIcon(Resource.Drawable.navigation_empty_icon)
                      .SetFullScreenIntent(fullScreenIntent, true);
            builder.SetPriority(NotificationCompat.PriorityHigh);
            return builder;
        }

        //Create intent for opening the related view.
        private PendingIntent GetIncomingCallPendingIntent(bool startActivity = true)
        {
            var intent = new Intent(Android.App.Application.Context, typeof(MainActivity));
            intent.PutExtra("LaunchData", "testData");
            intent.AddFlags(ActivityFlags.SingleTop);
            if (startActivity)
                Android.App.Application.Context.StartActivity(intent);
            return PendingIntent.GetActivity(Android.App.Application.Context, _requestCode++, intent, PendingIntentFlags.CancelCurrent);
        }

        private void CreateNotificationChannel()
        {
            try
            {
                if (Build.VERSION.SdkInt >= BuildVersionCodes.O)
                {
                    if (_nativeNotificationManager == null)
                        _nativeNotificationManager = (NotificationManager)Android.App.Application.Context.GetSystemService(Context.NotificationService);

                    _channelID = "NOTIFICATION_CHANNEL_1";
                    var channelName = "Test notification";

                    var oldChannel = _nativeNotificationManager.GetNotificationChannel(_channelID);
                    if (oldChannel != null) return;

                    NotificationChannel notificationChannel = new NotificationChannel(_channelID, channelName, NotificationImportance.High);
                    notificationChannel.LockscreenVisibility = NotificationVisibility.Public;
                    notificationChannel.EnableVibration(true);
                    notificationChannel.Importance = NotificationImportance.High;

                    _nativeNotificationManager.CreateNotificationChannel(notificationChannel);
                }
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine($"CreateNotificationChannel Error {ex.Message}");
            }
        }

        private void WakeUpScreenAsync()
        {
            PowerManager powerManager = (PowerManager)Android.App.Application.Context.GetSystemService(Context.PowerService);
            bool isScreenOn = powerManager.IsInteractive;
            if (!isScreenOn)
            {
                WakeLock wakeLock = powerManager.NewWakeLock(WakeLockFlags.ScreenDim | WakeLockFlags.AcquireCausesWakeup, "StackQAXFNotification");
                wakeLock.Acquire();
                wakeLock.Release();
            }
        }
    }
}
