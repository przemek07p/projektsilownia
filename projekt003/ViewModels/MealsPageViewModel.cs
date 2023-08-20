using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using projekt003.Buisness;
using projekt003.Models;
using projekt003.Pages;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    public class MealsPageViewModel : INotifyPropertyChanged
    {
        private bool isFlyoutMenuOpen;
        public bool IsFlyoutMenuOpen
        {
            get { return isFlyoutMenuOpen; }
            set { isFlyoutMenuOpen = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsFlyoutMenuOpen))); }
        }

        public ICommand FlyoutMenuButtonClickedCommand { get; set; }
        private void FlyoutMenuButtonClicked()
        {
            IsFlyoutMenuOpen = true;
        }

        const int RefreshDuration = 2;
        bool isRefreshing;

        public bool IsRefreshing
        {
            get
            {
                return isRefreshing;
            }
            set
            {
                isRefreshing = value;
                OnPropertyChanged();
            }
        }
        async Task RefreshDataAsync()
        {
            IsRefreshing = true;
            await Task.Delay(TimeSpan.FromSeconds(RefreshDuration));
            IsRefreshing = false;            
        }

        void OnPropertyChanged([CallerMemberName] string propertyName = null)
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        public ICommand RefreshCommand => new Command(async () => await RefreshDataAsync());

        public Command OnAppearingCommand { get; set; }        
        public ICommand DodajSkladnikButtonCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        public void DodajSkladnikButton()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewMealComponentPage());
        }            

        public MealsPageViewModel()
        {            
            this.DodajSkladnikButtonCommand = new Command(DodajSkladnikButton);
            FlyoutMenuButtonClickedCommand = new Command(FlyoutMenuButtonClicked);
        }


        public ObservableCollection<MainPageToDoListItem> ToDoListItems { get; set; }


        private string _tittle;
        public string Tittle
        {
            get
            {
                return _tittle;
            }
            set
            {
                _tittle = value;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs("Tittle"));
            }
        }

    }
}
