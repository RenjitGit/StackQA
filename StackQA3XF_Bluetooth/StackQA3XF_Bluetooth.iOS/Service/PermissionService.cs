using System;
using CoreBluetooth;
using CoreFoundation;
using StackQA3XF_Bluetooth.iOS.Service;
using StackQA3XF_Bluetooth.Services;
using UIKit;
using Xamarin.Forms;

[assembly: Dependency(typeof(PermissionService))]

namespace StackQA3XF_Bluetooth.iOS.Service
{

    public class PermissionService : IPermissionService
    {
        Action _bluetoothAction = null; //Optional, if you wanted to notify user that you have performed action (allow or deny) on the permission request dialog

        public bool HasBluetoothPermission()
        {
            if (UIDevice.CurrentDevice.CheckSystemVersion(13, 0))
            {
                return CBCentralManager.Authorization == CBManagerAuthorization.AllowedAlways;
            }
            else
            {
                return true;
            }
        }

        public void RequestBluetoothPermission(Action bluetoothAction)
        {
            _bluetoothAction = bluetoothAction;
            var myDelegate = new PermissionCBCentralManager(this);
            var centralManger = new CBCentralManager(myDelegate, DispatchQueue.MainQueue, new CBCentralInitOptions() { ShowPowerAlert = false });
        }

        internal void CurrentUpdatedState(CBCentralManager central)
        {
            _bluetoothAction.Invoke();
        }
    }

    public class PermissionCBCentralManager : CBCentralManagerDelegate
    {
        PermissionService permissionService = null;

        public PermissionCBCentralManager(PermissionService controller)
        {
            permissionService = controller;
        }

        public override void UpdatedState(CBCentralManager central)
        {
            permissionService.CurrentUpdatedState(central);
        }
    }
}

