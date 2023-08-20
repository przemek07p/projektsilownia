using projekt003.Buisness;
using projekt003.Models;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    public class RegistrationPageViewModel : INotifyPropertyChanged
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

        private string repeatedPasswordValue;
        public string RepeatedPasswordValue
        {
            get { return repeatedPasswordValue; }
            set { repeatedPasswordValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RepeatedPasswordValue))); }
        }

        public ICommand ZarejestrujButtonCommand { get; set; }

        public RegistrationPageViewModel()
        {
            ZarejestrujButtonCommand = new Command(ZarejestrujButton);
        }

        public void ZarejestrujButton()
        {
            try
            {
                var users = Session.GetInstance().Database.Users.GetAllUsers();
                if (users.Any(x => x.Login == this.LoginValue)) { throw new Exception($"User with login {LoginValue} already exist !!!"); }


                if (PasswordValue != RepeatedPasswordValue) { throw new Exception("Password must be equal to repeated!!!"); }

                Session.GetInstance().Database.Users.InsertUser(new User
                {
                    Id = Guid.NewGuid().ToString(),
                    Login = LoginValue,
                    Pin = PasswordValue
                });
            }
            catch (Exception ex)
            {

                App.Current.MainPage.DisplayAlert("Registration error", ex.Message, "Ok");
            }
            
        }

        public event PropertyChangedEventHandler PropertyChanged;
    }
}
