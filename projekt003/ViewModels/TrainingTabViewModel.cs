using projekt003.Pages;
using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    public class TrainingTabViewModel : INotifyPropertyChanged
    {
        public TrainingTabViewModel()
        {
            AddTrainingClickCommand = new Command(AddTrainingClick);
            
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand AddTrainingClickCommand { get; set; }
       

        private void AddTrainingClick()
        {
            App.Current.MainPage.Navigation.PushAsync(new AddTrainingDayPage());
            
        }
        
    }
}
