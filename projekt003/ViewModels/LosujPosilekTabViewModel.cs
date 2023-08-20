using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Text;
using System.Windows.Input;
using Xamarin.Forms;
using System.Threading.Tasks;
using projekt003.Buisness;
using Newtonsoft.Json;
using projekt003.Models;
using System.Linq;
using System.Collections.ObjectModel;
using System.Reflection;

namespace projekt003.ViewModels
{
    public class LosujPosilekTabViewModel : INotifyPropertyChanged
    {
        public LosujPosilekTabViewModel()
        {
            Ingredients = new ObservableCollection<KeyValuePair<string, string>>();
            GetButtonClickedCommand = new Command(GetButtonClicked);
            this.CaloriesOptions = new List<string>
            {
                "0-300",
                "300-500",
                "500-800",
                "800-1100",
                "1100-1500"
            };
        }

        private bool isAnimationRunning;

        private ObservableCollection<KeyValuePair<string, string>> ingredients;

        public ObservableCollection<KeyValuePair<string, string>> Ingredients
        {
            get { return ingredients; }
            set { ingredients = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredients))); }
        }


        public List<string> CaloriesOptions { get; set; }

        public string SelectedItem { get; set; }

        public ICommand GetButtonClickedCommand { get; set; }

        private Meal meal;
        public Meal Meal
        {
            get { return meal; }
            set 
            { 
                meal = value; 
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Meal)));
                var newList = new ObservableCollection<KeyValuePair<string, string>>();
                for (int i = 1; i < 21; i++)
                {
                    
                    var temp = value[$"strIngredient{i}"];
                    if (temp != null && temp != "") 
                    {
                        newList.Add(new KeyValuePair<string, string>(temp, value[$"strMeasure{i}"]));
                    }
                }
                Ingredients = newList;
                PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(Ingredients)));
            }
        }

        private async void GetButtonClicked()
        {
            if (Session.GetInstance().IsAppBusy) { return; }

            try
            {
                Session.GetInstance().IsAppBusy = true;
                await Task.Run(async () =>
                {
                    IsAnimationRunning = true;

                    using (var api = new WebApiMethods())
                    {
                        var json = api.GetMeal("https://www.themealdb.com/api/json/v1/1/random.php", "GET");
                        var response =  JsonConvert.DeserializeObject<Root> (json);
                        Meal = response.meals.FirstOrDefault();
                    }

                    IsAnimationRunning = false;
                });
            }
            catch (Exception ex)
            {
                if (ex.Message != "Object reference not set to an instance of an object.")
                await App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
            finally
            {
                Session.GetInstance().IsAppBusy = false;
            }

            
        }

        public bool IsAnimationRunning
        {
            get { return isAnimationRunning; }
            set { isAnimationRunning = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsAnimationRunning))); }
        }

        public event PropertyChangedEventHandler PropertyChanged;


    }
}
