using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StackQA2XF.CustomControl
{
    public partial class MyCustomControl : ContentView
    {
        public static readonly BindableProperty LableTextProperty =
            BindableProperty.Create(nameof(LableText), typeof(string), typeof(MyCustomControl), default(string), BindingMode.OneWay);

        public string LableText
        {
            get { return (string)GetValue(LableTextProperty); }
            set { SetValue(LableTextProperty, value); }
        }

        public MyCustomControl()
        {
            InitializeComponent();
            cLabel.SetBinding(Label.TextProperty, new Binding(nameof(LableText), source: this));
        }
    }
}
