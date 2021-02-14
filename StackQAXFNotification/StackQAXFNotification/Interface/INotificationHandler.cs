using System;
namespace StackQAXFNotification.Interface
{
    public interface INotificationHandler
    {
        void CreateNotification(string title, string message);
    }
}
