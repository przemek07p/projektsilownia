using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekt003.Buisness;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projekt003.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class MealsPageTabContent : ContentView
    {
        public MealsPageTabContent()
        {
            BindingContext = this;
            InitializeComponent();

            var skladniki = Session.GetInstance().Database.Skladnik.GetAllSkladnik();
            listOfComponents.ItemsSource = skladniki.OrderByDescending(x => x.DateTime);
        }
        private void SfButton_Clicked(object sender, EventArgs e)
        {
            Navigation.PushAsync(new SettingsPage());
        }

        private void SfButton_Clicked_1(object sender, EventArgs e)
        {
            App.Current.MainPage = new NavigationPage(new LoginPage());

        }
                
    }
}