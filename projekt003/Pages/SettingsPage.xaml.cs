using projekt003.Helpers;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using projekt003.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projekt003.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class SettingsPage : ContentPage
    {
       public SettingsPage()
        {
            BindingContext = new SettingsPageViewModel();  
        
            InitializeComponent();
            switch (Setting.Theme)
            {
                case 0:
                    RadioButtonSystem.IsChecked = true;
                    break;
                case 1:
                    RadioButtonLight.IsChecked = true;
                    break;
                case 2:
                    RadioButtonDark.IsChecked = true;
                    break;
            }
        }

        bool loaded;
        protected override void OnAppearing()
        {
            base.OnAppearing();
            loaded = true;
        }

        void RadioButton_CheckedChanged(object sender, CheckedChangedEventArgs e)
        {
            if (!loaded)
                return;

            if (!e.Value)
                return;

            var val = (sender as RadioButton)?.Value as string;
            if (string.IsNullOrWhiteSpace(val))
                return;

            switch (val)
            {
                case "System":
                    Setting.Theme = 0;
                    break;
                case "Light":
                    Setting.Theme = 1;
                    break;
                case "Dark":
                    Setting.Theme = 2;
                    break;
            }

            TheTheme.SetTheme();
        }
    }
}