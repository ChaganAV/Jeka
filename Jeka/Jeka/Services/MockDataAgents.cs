using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Jeka.Models;
using Jeka.Services;

namespace Jeka.Services
{
    public class MockDataAgents : IDataAgents<Agent>
    {
        readonly List<Agent> agents;
        public MockDataAgents()
        {
            agents = new List<Agent>()
            {
                new Agent() {Id = Guid.NewGuid().ToString(),Name = "Вася", Description = "кв 1"},
                new Agent() {Id = Guid.NewGuid().ToString(),Name = "Петя", Description = "кв 2"},
                new Agent() {Id = Guid.NewGuid().ToString(),Name = "Коля", Description = "кв 3"},
                new Agent() {Id = Guid.NewGuid().ToString(),Name = "Лиля", Description = "кв 4"},
                new Agent() {Id = Guid.NewGuid().ToString(),Name = "Елена", Description = "кв 5"}
            };
        }
        public async Task<bool> AddAgentAsync(Agent agent)
        {
            agents.Add(agent);
            return await Task.FromResult(true);
        }
        public async Task<bool> UpdateAgentAsync(Agent agent)
        {
            var agentOld = agents.Where((Agent a) => a.Id == agent.Id).FirstOrDefault();
            agents.Remove(agentOld);
            agents.Add(agent);

            return await Task.FromResult(true);
        }

        public async Task<bool> DeleteAgentAsync(string id)
        {
            var agentOld = agents.Where((Agent a) => a.Id == id).FirstOrDefault();
            agents.Remove(agentOld);

            return await Task.FromResult(true);
        }
        public async Task<Agent> GetAgentAsync(string id)
        {
            return await Task.FromResult(agents.Where((Agent a) => a.Id == id).FirstOrDefault());
        }

        public async Task<IEnumerable<Agent>> GetAgentsAsync(bool forceRefresh = false)
        {
            return await Task.FromResult(agents);
        }
    }
}
