using projekt003.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Xamarin.Forms;
using projekt003.ViewModels;
using projekt003.Buisness;

namespace projekt003
{
    public partial class MainPage : ContentPage
    {
        public MainPage()
        {            
            InitializeComponent();
            this.BindingContext = new MainPageViewModel();                     

        }

        private void SfButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void SfButton_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage( new LoginPage());

        }       
    }
}
