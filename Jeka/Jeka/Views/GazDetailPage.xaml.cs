using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeka.ViewModels;
using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jeka.Views
{
    [XamlCompilation(XamlCompilationOptions.Compile)]
    public partial class GazDetailPage : ContentPage
    {
        public GazDetailPage()
        {
            InitializeComponent();
            BindingContext = new GazDetailViewModel();
        }
    }
}