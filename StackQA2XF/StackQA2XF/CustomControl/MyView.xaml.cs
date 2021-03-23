using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace StackQA2XF.CustomControl
{
    public partial class MyCustomControl : ContentView
    {
        public static readonly BindableProperty EntryTextProperty =
            BindableProperty.Create(nameof(EntryText), typeof(string), typeof(MyCustomControl), default(string), BindingMode.TwoWay);

        public string EntryText
        {
            get { return (string)GetValue(EntryTextProperty); }
            set { SetValue(EntryTextProperty, value); }
        }

        public MyCustomControl()
        {
            InitializeComponent();
            CustomEntry.SetBinding(Entry.TextProperty, new Binding(nameof(EntryText), source: this));
        }
    }
}
