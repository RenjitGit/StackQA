using System;
using StackQA2XF.Services;
using Xamarin.Forms;

[assembly: Dependency(typeof(StackQA2XF.Droid.Service.PermissionService))]
namespace StackQA2XF.Droid.Service
{
    public class PermissionService : IPermissionService
    {
        public bool HasBluetoothPermission()
        {
            throw new NotImplementedException();
        }

        public void RequestBluetoothPermission(Action bluetoothAction)
        {
            throw new NotImplementedException();
        }
    }


}
