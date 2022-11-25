using System;
using System.Collections.Generic;
using System.Collections.ObjectModel;
using System.Diagnostics;
using System.Text;
using System.Threading.Tasks;
using Jeka.Models;
using Jeka.Views;
using Xamarin.Forms;

namespace Jeka.ViewModels
{
    class GazViewModel : BaseViewModel
    {
        private Agent _selectedAgent;

        public ObservableCollection<Agent> Agents { get; }
        public Command LoadAgentCommand { get; }
        public Command AddAgentCommand { get; }
        public Command<Agent> AgentTapped { get; }

        public GazViewModel()
        {
            Title = "Газ";
            Agents = new ObservableCollection<Agent>();
            LoadAgentCommand = new Command(async () => await ExecuteLoadAgentCommand());

            AgentTapped = new Command<Agent>(OnAgentSelected);

            AddAgentCommand = new Command(OnAddAgent);
        }
        async Task ExecuteLoadAgentCommand()
        {
            IsBusy = true;

            try
            {
                Agents.Clear();
                var agents = await DataAgents.GetAgentsAsync(true);
                foreach (var agent in agents)
                {
                    Agents.Add(agent);
                }
            }
            catch (Exception ex)
            {
                Debug.WriteLine(ex);
            }
            finally
            {
                IsBusy = false;
            }
        }
        public void OnAppearing()
        {
            IsBusy = true;
            SelectedAgent = null;
        }
        public Agent SelectedAgent
        {
            get => _selectedAgent;
            set
            {
                SetProperty(ref _selectedAgent, value);
                OnAgentSelected(value);
            }
        }

        private async void OnAddAgent(object obj)
        {
            await Shell.Current.GoToAsync(nameof(NewAgentPage));
        }
        async void OnAgentSelected(Agent agent)
        {
            if (agent == null)
                return;

            // This will push the ItemDetailPage onto the navigation stack
            await Shell.Current.GoToAsync($"{nameof(ItemDetailPage)}?{nameof(ItemDetailViewModel.ItemId)}={agent.Id}");
        }
    }
}
