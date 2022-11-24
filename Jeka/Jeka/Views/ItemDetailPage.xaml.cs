using Jeka.ViewModels;
using System.ComponentModel;
using Xamarin.Forms;

namespace Jeka.Views
{
    public partial class ItemDetailPage : ContentPage
    {
        public ItemDetailPage()
        {
            InitializeComponent();
            BindingContext = new ItemDetailViewModel();
        }
    }
}