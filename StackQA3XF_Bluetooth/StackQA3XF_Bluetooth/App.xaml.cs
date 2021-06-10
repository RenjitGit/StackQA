using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackQA3XF_Bluetooth
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new BluetoothPermissionPage();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
