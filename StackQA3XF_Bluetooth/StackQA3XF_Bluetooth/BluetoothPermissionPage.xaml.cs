using System;
using System.Collections.Generic;
using StackQA3XF_Bluetooth.Services;
using Xamarin.Forms;

namespace StackQA3XF_Bluetooth
{
    public partial class BluetoothPermissionPage : ContentPage
    {
        IPermissionService service;

        public BluetoothPermissionPage()
        {
            InitializeComponent();
            service = DependencyService.Get<IPermissionService>();
        }

        protected override void OnAppearing()
        {
            base.OnAppearing();
            CheckBluetooothPermission();
        }

        void HasBluetooth_Clicked(System.Object sender, System.EventArgs e)
        {
            CheckBluetooothPermission();
        }

        private void CheckBluetooothPermission()
        {
            LabelHasPermission.Text = service.HasBluetoothPermission() ? "YES" : "NO";
        }

        void RequestBluetooth_Clicked(System.Object sender, System.EventArgs e)
        {
            service.RequestBluetoothPermission(() =>
            {
                CheckBluetooothPermission();
            });
        }
    }
}
