using System;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IJobRepository : IBaseRepository<Job>
	{
		Task<List<Job>> GetProjectJobs(Guid id);
	}
}

