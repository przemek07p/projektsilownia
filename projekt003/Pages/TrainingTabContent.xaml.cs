﻿using projekt003.ViewModels;
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
    public partial class TrainingTabContent : ContentView
    {
        public TrainingTabContent()
        {
            BindingContext = new TrainingTabViewModel();
            InitializeComponent();
        }
    }
}