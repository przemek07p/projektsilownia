using projekt003.Buisness;
using projekt003.Models;
using projekt003.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    internal class ZmianaHaslaPageViewModel : INotifyPropertyChanged
    {

        private string newpasswordValue;
        public string newPasswordValue
        {
            get { return newpasswordValue; }
            set { newpasswordValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(newPasswordValue))); }
        }

        private string newrepeatedPasswordValue;
        public string newRepeatedPasswordValue
        {
            get { return newrepeatedPasswordValue; }
            set { newrepeatedPasswordValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(newRepeatedPasswordValue))); }
        }

        public ICommand ZmienHasloButtonCommand { get; set; }

        public ZmianaHaslaPageViewModel()
        {
            this.ZmienHasloButtonCommand = new Command(ZmienHasloButton);
        }

        public void ZmienHasloButton()
        {

            


            try
            {
               // var users = Session.GetInstance().Database.Users.GetAllUsers();
               // if (users.Any(x => x.Login == this.LoginValue)) { throw new Exception($"User with login {LoginValue} already exist !!!"); }


                if (newPasswordValue != newRepeatedPasswordValue) { throw new Exception("Password must be equal to repeated!!!"); }

                Session.GetInstance().Database.Users.InsertUser(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    //Login = LoginValue,
                    Pin = newPasswordValue
                });
                App.Current.MainPage.Navigation.PushAsync(new SettingsPage());
            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Registration error", ex.Message, "Ok");
            }
        }

        

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
