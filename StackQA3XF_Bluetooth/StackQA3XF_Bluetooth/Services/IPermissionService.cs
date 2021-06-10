using System;
namespace StackQA3XF_Bluetooth.Services
{
    public interface IPermissionService
    {
        bool HasBluetoothPermission();
        void RequestBluetoothPermission(Action bluetoothAction);
    }
}
