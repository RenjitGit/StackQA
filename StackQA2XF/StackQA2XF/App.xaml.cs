﻿using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace StackQA2XF
{
    public partial class App : Application
    {
        public App()
        {
            InitializeComponent();

            MainPage = new WebviewInList();
        }

        protected override void OnStart()
        {
        }

        protected override void OnSleep()
        {
        }

        protected override void OnResume()
        {
        }
    }
}
