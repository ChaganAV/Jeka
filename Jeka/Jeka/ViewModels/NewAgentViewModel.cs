using System;
using System.Collections.Generic;
using System.Text;
using Jeka.Models;
using Jeka.ViewModels;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Jeka.ViewModels
{
    public class NewAgentViewModel : BaseViewModel
    {
        private string name;
        private string description;

        public NewAgentViewModel()
        {
            SaveCommand = new Command(OnSave, ValidateSave);
            CancelCommand = new Command(OnCancel);
            this.PropertyChanged += (_, __) => SaveCommand.ChangeCanExecute();
        }
        private bool ValidateSave()
        {
            return !String.IsNullOrWhiteSpace(name)
                && !String.IsNullOrWhiteSpace(description);
        }
        public string Name
        {
            get { return name; }
            set { SetProperty(ref name, value); }
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public Command SaveCommand { get; }
        public Command CancelCommand { get; }

        private async void OnCancel()
        {
            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
        private async void OnSave()
        {
            Agent newAgent = new Agent()
            {
                Id = Guid.NewGuid().ToString(),
                Name = Name,
                Description = Description
            };

            await DataAgents.AddAgentAsync(newAgent);

            // This will pop the current page off the navigation stack
            await Shell.Current.GoToAsync("..");
        }
    }
}
