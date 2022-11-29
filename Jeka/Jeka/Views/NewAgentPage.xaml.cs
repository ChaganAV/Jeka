using Jeka.Models;
using Jeka.ViewModels;
using System;
using System.Collections.Generic;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jeka.Views
{
    public partial class NewAgentPage : ContentPage
    {
        public Agent Agent { get; set; }
        public NewAgentPage()
        {
            InitializeComponent();
            BindingContext = new NewAgentViewModel();
        }
    }
}