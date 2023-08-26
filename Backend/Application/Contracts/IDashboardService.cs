using Application.DTOs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Contracts
{
    public interface IDashboardService
    {
        Task<List<Stat>> getCountEntities();
        Task<List<ProjectPerClient>> GetProjectPerClients();
    }
}
