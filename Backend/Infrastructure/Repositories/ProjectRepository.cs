using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class ProjectRepository : BaseRepository<Project>, IProjectRepository
    {
        public ProjectRepository(DataContext context) : base(context) { }

        public Task<List<Project>> GetProjectWithClientAndUser()
        {
            return _context.Projects.Include(p => p.User).Include(p => p.Client).ToListAsync();
        }
    }
}