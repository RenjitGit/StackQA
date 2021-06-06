using System;

namespace StackQA2XF.Services
{
    public interface IPermissionService
    {
        bool HasBluetoothPermission();
        void RequestBluetoothPermission(Action bluetoothAction);
    }
}
