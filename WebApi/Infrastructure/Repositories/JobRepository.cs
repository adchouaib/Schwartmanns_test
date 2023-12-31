﻿using System;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class JobRepository : BaseRepository<Job>, IJobRepository
    {
        public JobRepository(DataContext context) : base(context) { }

        public Task<List<Job>> GetProjectJobs(Guid id)
        {
            return _context.Jobs
                .Include(j => j.Project)
                .Include(j => j.Project.User)
                .Include(j => j.Project.Client)
                .Where(j => j.ProjectId == id).ToListAsync();
        }
    }
}

