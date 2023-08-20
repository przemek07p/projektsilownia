using MonkeyCache.FileStore;
using projekt003.Helpers;
using System;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;
using Syncfusion;
using projekt003.Pages;
using Xamarin.Essentials;

namespace projekt003
{
    public partial class App : Application
    {
        public App()
        {
            //wersja 20.1.0.55
            Syncfusion.Licensing.SyncfusionLicenseProvider.RegisterLicense("NjIzNjU4QDMyMzAyZTMxMmUzMFVoemdGaVlOQ1BJa3Babm1XOVdvVU9GaCtNbjR4MVV4RkNRZi9GQVdXZzg9");

            

            InitializeComponent();

            ///for test purpose only
            //////////////////////////////////////////
            //MainPage = new NavigationPage( new Test());
           //MainPage = new NavigationPage(new TestPage());
            //MainPage = new NavigationPage(new AddTrainingDayPage());
            //MainPage = new NavigationPage( new MainPage());
            //////////////////////////////////////////

            MainPage = new NavigationPage(new LoginPage());



            TheTheme.SetTheme();

            Barrel.ApplicationId = AppInfo.PackageName;

        }

        protected override void OnStart()

        {
            OnResume();
        }

        protected override void OnSleep()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged -= App_RequestedThemeChanged;
        }

        protected override void OnResume()
        {
            TheTheme.SetTheme();
            RequestedThemeChanged += App_RequestedThemeChanged;
        }

        private void App_RequestedThemeChanged(object sender, AppThemeChangedEventArgs e)
        {
            MainThread.BeginInvokeOnMainThread(() =>
            {
                TheTheme.SetTheme();
            });
        }
    }
}
