using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using StackQAXFNotification.Interface;
using Xamarin.Forms;

namespace StackQAXFNotification
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            Notification();
        }

        public async Task Notification()
        {
            try
            {
                await Task.Delay(2000);
                INotificationHandler service = DependencyService.Get<INotificationHandler>();
                service.CreateNotification("Test title", "Test content");
            }
            catch (Exception ex)
            {
                System.Diagnostics.Debug.WriteLine(ex.Message);
            }
         
        }
    }
}
