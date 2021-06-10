using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using Xamarin.Forms;

namespace StackQA2XF
{
    public partial class WebviewInList : ContentPage
    {
        public WebviewInList()
        {
            InitializeComponent();

            this.BindingContext = new WebViewInListViewModel();
        }
    }

    public class WebViewInListViewModel : INotifyPropertyChanged
    {
        public List<WebViewInListModel> SourceList { get; set; }

        public string HtmlContent1 { get; set; } = @"https://dotnet.microsoft.com/apps/xamarin";

        public WebViewInListViewModel()
        {
            ConstructList();
        }

        public void ConstructList()
        {
            var list = new List<WebViewInListModel>();

            for (int i = 0; i < 20; i++)
            {
                list.Add(new WebViewInListModel());
            }

            SourceList = list;
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public bool SetProperty<T>(ref T storage, T value, [CallerMemberName] string propertyName = null)
        {
            if (EqualityComparer<T>.Default.Equals(storage, value)) return false;
            storage = value;
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
            return true;
        }
    }

    public class WebViewInListModel
    {
        public string HtmlContent { get; set; } = @"<html>
<body>
<h1> My First Heading</h1>
<p>My first paragraph.</p>
</body>
</html>";

        public WebViewInListModel(string htmlContent)
        {
            HtmlContent = htmlContent;
        }

        public WebViewInListModel()
        {

        }
    }
}

