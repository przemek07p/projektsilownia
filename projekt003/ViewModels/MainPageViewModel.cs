using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Reflection;
using System.Text;
using System.Windows.Input;
using FFImageLoading.Forms;
using projekt003.Buisness;
using projekt003.Models;
using projekt003.Pages;
using Xamarin.Forms;
using System.Drawing;

namespace projekt003.ViewModels
{
    public class MainPageViewModel : INotifyPropertyChanged
    {
        public ICommand DodajSkladnikButtonCommand { get; set; }
        public void DodajSkladnikButton()
        {
            App.Current.MainPage.Navigation.PushAsync(new NewMealComponentPage());
        }

        //public ICommand DodajPosilekButtonCommand { get; set; }
       


        //public void DodajPosilekButton()
        //{

        //    App.Current.MainPage.Navigation.PushAsync(new MealsPage());
        //}
        public ObservableCollection<MainPageToDoListItem> ToDoListItems { get; set; }


        private string _tittle;
        public string Tittle {
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



        public event PropertyChangedEventHandler PropertyChanged;


        public ObservableCollection<string> imageList { get; set; }
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




        public MainPageViewModel()
        {
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
            imageList = new ObservableCollection<string>();
            foreach (var item in x)
            {
                imageList.Add($"resource://projekt003.Pictures.{item}.png");
            }

            //var imageStream = Assembly.GetExecutingAssembly().GetManifestResourceStream("projekt003.Pictures.barki.png");
            //if(imageStream!=null)
            //{

            //    //var t = ImageSource.FromStream()
            //}

            this.DodajSkladnikButtonCommand = new Command(DodajSkladnikButton);

            //this.DodajPosilekButtonCommand = new Command(DodajPosilekButton);

            FlyoutMenuButtonClickedCommand = new Command(FlyoutMenuButtonClicked);
            this.ToDoListItems = new ObservableCollection<MainPageToDoListItem>();
            ToDoListItems.Add(new TrainigToDoListItem 
            { 
                Title = "Trening", 
                TrainingDuration = new TimeSpan(1, 15, 0), 
                IsMeal= false, 
                IsTraining = true
            });
            ToDoListItems.Add(new MealToDoListItem 
            {
                Title = "Posiłek", 
                MealType = "Śniadanie", 
                Calories = 700,
                IsMeal = true,
                IsTraining = false
            });
            ToDoListItems.Add(new MealToDoListItem 
            {
                Title = "Posiłek", 
                MealType = "Lunch", 
                Calories = 500,
                IsMeal = true,
                IsTraining = false
            });
            ToDoListItems.Add(new MealToDoListItem
            {
                Title = "Posiłek",
                MealType = "Obiad",
                Calories = 1000,
                IsMeal = true,
                IsTraining = false
            });
            ToDoListItems.Add(new MealToDoListItem
            {
                Title = "Posiłek",
                MealType = "Kolacja",
                Calories = 500,
                IsMeal = true,
                IsTraining = false
            });
        }

    }
}
