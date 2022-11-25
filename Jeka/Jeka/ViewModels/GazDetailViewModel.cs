using Jeka.Models;
using System;
using System.Collections.Generic;
using System.Diagnostics;
using System.Text;
using Xamarin.Forms;
using static System.Net.Mime.MediaTypeNames;

namespace Jeka.ViewModels
{
    [QueryProperty(nameof(AgentId), nameof(AgentId))]
    public class GazDetailViewModel : BaseViewModel
    {
        private string agentId;
        private string name;
        private string description;

        public string Id { get; set; }
        public string Name 
        {
            get => name;
            set => SetProperty(ref name, value); 
        }
        public string Description
        {
            get => description;
            set => SetProperty(ref description, value);
        }
        public string AgentId
        {
            get => agentId;
            set 
            {
                agentId = value;
                LoadAgentId(value);
            }
        }
        public async void LoadAgentId(string agentId)
        {
            try
            {
                var agent = await DataAgents.GetAgentAsync(agentId);
                Id = agent.Id;
                Name = agent.Name;
                Description = agent.Description;
            }
            catch (Exception)
            {
                Debug.WriteLine("Не получилось загрузить абонента");
            }
        }
    }
}
