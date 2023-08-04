using System;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class SheetRepository : BaseRepository<Sheet>, ISheetRepository
    {
        public SheetRepository(DataContext context) : base(context) { }

        public Task<List<Sheet>> GetJobSheets(Guid projectId, Guid jobId)
        {
            return  _context.Jobs
                        .Where(j => j.ProjectId == projectId && j.Id == jobId)
                        .SelectMany(j => j.Sheets)
                        .ToListAsync();
        }

        public Task<Sheet?> GetSheetWithComponents(Guid projectId, Guid jobId, Guid sheetId)
        {
            return _context.Jobs
                        .Include(j => j.Sheets)
                        .Where(j => j.ProjectId == projectId && j.Id == jobId)
                        .SelectMany(j => j.Sheets)
                        .Include(s => s.Circles)
                        .Include(s => s.PolyLines)
                        .Where(s => s.Id == sheetId)
                        .FirstOrDefaultAsync();

        }
    }
}

