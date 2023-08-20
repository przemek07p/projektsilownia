using projekt003.Buisness;
using projekt003.Models;
using projekt003.Pages;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Globalization;
using System.Linq;
using System.Runtime.CompilerServices;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    public class NewMealComponentPageViewModel : INotifyPropertyChanged
    {
        private string nazwaSkladnikaValue;

        public string NazwaSkladnikaValue
        {
            get { return nazwaSkladnikaValue; }
            set { nazwaSkladnikaValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(NazwaSkladnikaValue))); }
        }

        private int kalorycznoscSkladnikaValue;

        public int KalorycznoscSkladnikaValue
        {
            get { return kalorycznoscSkladnikaValue; }
            set { kalorycznoscSkladnikaValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(KalorycznoscSkladnikaValue))); }
        }

        private float weglowodanyValue;
        public float WeglowodanyValue
        {
            get { return weglowodanyValue; }
            set { weglowodanyValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(WeglowodanyValue))); }
        }

        private float bialkoValue;
        public float BialkoValue
        {
            get { return bialkoValue; }
            set { bialkoValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(BialkoValue))); }
        }

        private float tluszczValue;
        public float TluszczValue
        {
            get { return tluszczValue; }
            set { tluszczValue = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(TluszczValue))); }
        }

        public event PropertyChangedEventHandler PropertyChanged;

        public ICommand ZapiszSkladnikButtonCommand { get; set; }

        private void NotifyPropertyChanged([CallerMemberName] String propertyName = "")
        {
            PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(propertyName));
        }

        private object selectedItem;
        public object SelectedItem
        {
            get { return selectedItem; }
            set
            {
                selectedItem = value;
                NotifyPropertyChanged();
            }
        }

        public NewMealComponentPageViewModel()
        {
            this.ZapiszSkladnikButtonCommand = new Command(ZapiszSkladnikButton);
        }
        public IList<string> NazwaPosilkuValue
        {
            get
            {
                return new List<string> {"Śniadanie", "Obiad", "Kolacja", "Poranna przekąska", "Popoł. przekąska", "Wiecz. przekąska" };
            }
        }

       

        public void ZapiszSkladnikButton()
        {        
            try
            {
                if (SelectedItem is null) { throw new Exception($"Wybierz posiłek!!!"); }
                if (NazwaSkladnikaValue is null) { throw new Exception($"Składnik musi mieć nazwę!!!"); }                

                Session.GetInstance().Database.Skladnik.InsertSkladnik(new SkladnikPosilkuDTO
                {
                    MealType = SelectedItem.ToString(),
                    DateTime = DateTime.Now,
                    Id = Guid.NewGuid().ToString(),
                    Name = NazwaSkladnikaValue,
                    KCal = KalorycznoscSkladnikaValue,
                    Weglowodany = WeglowodanyValue,
                    Bialko = BialkoValue,
                    Tluszcz = TluszczValue
                });
                
                //App.Current.MainPage.Navigation.PopAsync();
                App.Current.MainPage = new NavigationPage(new MainPage());

            }
            catch (Exception ex)
            {
                App.Current.MainPage.DisplayAlert("Error", ex.Message, "Ok");
            }
        }
    }
}
