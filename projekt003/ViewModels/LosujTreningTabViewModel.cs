using Newtonsoft.Json;
using projekt003.Buisness;
using projekt003.Models;
using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.ComponentModel;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Windows.Input;
using Xamarin.Forms;

namespace projekt003.ViewModels
{
    public class LosujTreningTabViewModel : INotifyPropertyChanged
    {
        public LosujTreningTabViewModel()
        {
            GetButtonClickedCommand = new Command(GetButtonClicked);
            IsExcerciseFrameVisible = false;
            ChipModels = new ObservableCollection<ChipModel>();
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
            var imageList = new ObservableCollection<string>();
            foreach (var item in x)
            {
                ChipModels.Add(new ChipModel { PicturePath = $"resource://projekt003.Pictures.{item}.png", Caption = item.Equals("cyc") ? "klata" : item });
            }
        }

        private ObservableCollection<ChipModel> chipModels;
        private ChipModel selectedChip;
        private bool isExcerciseFrameVisible;
        private bool isAnimationRunning;



        public bool IsExcerciseFrameVisible
        {
            get { return isExcerciseFrameVisible; }
            set { isExcerciseFrameVisible = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(IsExcerciseFrameVisible))); }
        }

        public ChipModel SelectedChip
        {
            get { return selectedChip; }
            set {  selectedChip = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(SelectedChip))); }
        }

        public ObservableCollection<ChipModel> ChipModels
        {
            get { return chipModels; }
            set { chipModels = value; PropertyChanged?.Invoke(this, new PropertyChangedEventArgs(nameof(ChipModel))); }
        }

        public ICommand GetButtonClickedCommand { get; set; }

        public event PropertyChangedEventHandler PropertyChanged;

        private async void GetButtonClicked()
        {
            if (Session.GetInstance().IsAppBusy) { return; }

            try
            {
                Session.GetInstance().IsAppBusy = true;
                await Task.Run(async () =>
                {
                    IsAnimationRunning = true;

                    
                    await Task.Delay(3000);
                    IsExcerciseFrameVisible = true;

                    IsAnimationRunning = false;
                });
            }
            catch (Exception ex)
            {
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



        public class ChipModel
        {
            public string Caption { get; set; }

            public string PicturePath { get; set; }
        }
    }
}
