using projekt003.ViewModels;
using Syncfusion.XForms.ComboBox;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace projekt003.Pages
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class NewMealComponentPage : ContentPage
    {
        public NewMealComponentPage()
        {
            BindingContext = new NewMealComponentPageViewModel();
            InitializeComponent();
        }
    }
    
}