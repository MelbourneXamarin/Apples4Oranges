﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

using Xamarin.Forms;

namespace Apples4Oranges
{
    public class App : Application
    {
        public App()
        {
            // The root page of your application
            TabbedPage navPage = new HomePage();
            var navHost = new NavigationPage(navPage);
            MainPage = navHost;
        }

        protected override void OnStart()
        {
            // Handle when your app starts
        }

        protected override void OnSleep()
        {
            // Handle when your app sleeps
        }

        protected override void OnResume()
        {
            // Handle when your app resumes
        }
    }
}
