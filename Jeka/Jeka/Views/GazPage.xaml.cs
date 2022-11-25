using Jeka.ViewModels;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

using Xamarin.Forms;
using Xamarin.Forms.Xaml;

namespace Jeka.Views
{
	[XamlCompilation(XamlCompilationOptions.Compile)]
	public partial class GazPage : ContentPage
	{
		GazViewModel _viewModel;
		public GazPage ()
		{
			InitializeComponent ();
			BindingContext = _viewModel = new GazViewModel ();
		}
        protected override void OnAppearing()
        {
            base.OnAppearing();
            _viewModel.OnAppearing();
        }
    }
}