using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface ISheetRepository : IBaseRepository<Sheet>
    {
        Task<List<Sheet>> GetJobSheets(Guid projectId, Guid jobId);
        Task<Sheet?> GetSheetWithComponents(Guid projectId, Guid jobId, Guid sheetId);
    }
}
