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
    public class LoginPageViewModel : INotifyPropertyChanged
    {
        private string loginValue;

        public string LoginValue
        {
            get { return loginValue; }
            set { loginValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(LoginValue))); } 
        }

        private string passwordValue;
        public string PasswordValue
        {
            get { return passwordValue; }
            set { passwordValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(PasswordValue))); }
        }


        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ZalogujButtonCommand { get; set; }
        public ICommand ZarejestrujButtonCommand { get; set; } 

        public LoginPageViewModel()
        {
            this.ZalogujButtonCommand = new Command(ZalogujButton);
            this.ZarejestrujButtonCommand = new Command(ZarejestrujButton);
        }


        public void ZarejestrujButton()
        {
            App.Current.MainPage.Navigation.PushAsync(new RegistrationPage());
        }

        public void ZalogujButton()
        {
            try
            {
                var user = Session.GetInstance().Database.Users.GetUserByLogin(LoginValue);
                if (user == null) { throw new Exception($"No user {LoginValue} in base!!"); }
                if (user.Pin != this.PasswordValue) { throw new Exception("Wrong Password!"); }

                App.Current.MainPage = new NavigationPage(new MainPage());
            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Login error", ex.Message, "Ok");
            }
           

        }

      
    }
}
