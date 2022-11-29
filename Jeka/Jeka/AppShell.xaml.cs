using Jeka.ViewModels;
using Jeka.Views;
using System;
using System.Collections.Generic;
using Xamarin.Forms;

namespace Jeka
{
    public partial class AppShell : Xamarin.Forms.Shell
    {
        public AppShell()
        {
            InitializeComponent();
            Routing.RegisterRoute(nameof(ItemDetailPage), typeof(ItemDetailPage));
            Routing.RegisterRoute(nameof(NewItemPage), typeof(NewItemPage));
            Routing.RegisterRoute(nameof(GazDetailPage), typeof(GazDetailPage));
            Routing.RegisterRoute(nameof(NewAgentPage), typeof(NewAgentPage));
        }

    }
}
