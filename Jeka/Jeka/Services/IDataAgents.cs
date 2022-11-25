using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace Jeka.Services
{
    public interface IDataAgents<T>
    {
        Task<bool> AddAgentAsync(T agent);
        Task<bool> UpdateAgentAsync(T agent);
        Task<bool> DeleteAgentAsync(string id);
        Task<T> GetAgentAsync(string id);
        Task<IEnumerable<T>> GetAgentsAsync(bool forceRefresh = false);
    }
}
