using projekt003.Buisness;
using projekt003.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    internal class SettingsPageViewModel
    {
        public ICommand ZmienHasloButtonCommand { get; set; }

        public SettingsPageViewModel()
        {
            this.ZmienHasloButtonCommand = new Command(ZmienHasloButton);
        }
        public void ZmienHasloButton()
        {
            App.Current.MainPage.Navigation.PushAsync(new ZmianaHaslaPage());
        }
    }
}
