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
            this.BindingContext = new MainViewModel();
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

        private void OnStringSet(Application source, string lableText)
        {
            stack.Children.Add(new Label
            {
                Text = lableText,
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

    public class MainViewModel : INotifyPropertyChanged
    {
        private string _titleText = "Good morning";
        public string TitleText
        {
            get
            {
                return _titleText;
            }
            set
            {
                _titleText = value;
                OnPropertyChange(nameof(TitleText));
            }
        }

        public MainViewModel()
        {
            TitleText = "Hi Good morning";
            WhileLoop();
        }

        public async Task WhileLoop()
        {
            int i = 0;
            while (true)
            {
                await Task.Delay(1000);
                TitleText = $"Good morning {i++}";
            }
        }
       
        public event PropertyChangedEventHandler PropertyChanged;
        public void OnPropertyChange(string propName)
        {
            if (PropertyChanged != null)
            {
                PropertyChanged(this, new PropertyChangedEventArgs(propName));
            }
        }
    }
}
