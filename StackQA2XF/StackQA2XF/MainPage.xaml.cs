using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;

namespace StackQA2XF
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {
            InitializeComponent();
            MessagingCenter.Instance.Subscribe<Application, Stream>(Application.Current, "ImageSent", OnImageSent);
            MessagingCenter.Instance.Subscribe<Application, string>(Application.Current, "StringTest", OnStringSet);
        }

        private void OnImageSent(Application source, Stream imageStream)
        {
            var imageSource = ImageSource.FromStream(() => imageStream);
            stack.Children.Add(new Image
            {
                Source = imageSource,
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 100,
                HeightRequest = 100,
            }); ;
        }

        private void OnStringSet(Application source, string imageStream)
        {
            stack.Children.Add(new Label
            {
                Text = imageStream,
                VerticalOptions = LayoutOptions.Center
            });
            stack.Children.Add(new Image
            {
                Source = "completed_tab.png",
                VerticalOptions = LayoutOptions.Center,
                WidthRequest = 100,
                HeightRequest = 100,
            });
        }
    }
}
