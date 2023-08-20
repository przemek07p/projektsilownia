using Syncfusion.XForms.Pickers;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    public class AddTrainingDayVievModel : INotifyPropertyChanged
    {


        



    public event PropertyChangedEventHandler PropertyChanged;

        public ICommand BackArrowClickCommand { get; set; }


        //konstruktor
        public AddTrainingDayVievModel()
        {
            BackArrowClickCommand = new Command(BackArrowClick);
            AddExcercisedButtonClickCommand = new Command(AddExcercisedButtonClick);
            SaveButtonClickCommand = new Command(SaveButtonClick);

            var x = new List<string>
            {
                "barki",
                "biceps",
                "cyc",
                "kaloryfer",
                "lydki",
                "plecy",
                "posladki",
                "przedramie",
                "triceps",
                "uda"
            };
            MusclesList = new List<string>();
            foreach (var item in x)
            {
                MusclesList.Add($"resource://projekt003.Pictures.{item}.png");
            }

            

        }


        //zmienne lokalne
        private string nameOfMuscleEntryValue;
        private int seriesCounterNumericValue;
        private int repeatCounterNumericValue;
        private string selectedChipMuscle;
        private TimeSpan trainingTimePicker;



        //właściwości
        public string NameOfMuscleEntryValue
        {
            get { return nameOfMuscleEntryValue; }
            set { nameOfMuscleEntryValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NameOfMuscleEntryValue))); }
        }
        public int SeriesCounterNumericValue
        {
            get { return seriesCounterNumericValue; }
            set { seriesCounterNumericValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SeriesCounterNumericValue))); }
        }
        public int RepeatCounterNumericValue
        {
            get { return repeatCounterNumericValue; }
            set { repeatCounterNumericValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(RepeatCounterNumericValue))); }
        }
        public List<string> MusclesList { get; set; }

        public string SelectedChipMuscle 
        {
            get { return selectedChipMuscle; }
            set { selectedChipMuscle = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedChipMuscle))); }

        }
        public TimeSpan TrainingTimePicker 
        {
            get { return trainingTimePicker; }
            set { trainingTimePicker = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TrainingTimePicker))); }

        }

        public ICommand AddExcercisedButtonClickCommand { get; set; }
        public ICommand SaveButtonClickCommand { get; set; }
        

        private bool isPopupOpen;

        public bool IsPopupOpen 
        {
            get { return isPopupOpen; } 
            set { isPopupOpen = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsPopupOpen))); }
        }    
        private void SaveButtonClick()
        {
            var x = new Tuple<string,int, int>(NameOfMuscleEntryValue, SeriesCounterNumericValue, RepeatCounterNumericValue);
        }
        private void BackArrowClick()
        {
            App.Current.MainPage.Navigation.PopAsync();
        }
        
        private void AddExcercisedButtonClick()
        {


            switch (IsPopupOpen)
            {
                case true:
                    IsPopupOpen = false;
                    
                    break;
                case false:
                    IsPopupOpen = true;
                    break;
                default:
                    break;
            }


        }

    }
}
