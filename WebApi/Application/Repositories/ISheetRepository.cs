using System;
using Domain.Entities;

namespace Application.Repositories
{
	public interface ISheetRepository : IBaseRepository<Sheet>
	{
		Task<List<Sheet>> GetJobSheets(Guid projectId, Guid jobId);
		Task<Sheet?> GetSheetWithComponents(Guid projectId, Guid jobId, Guid sheetId);
	}
}

