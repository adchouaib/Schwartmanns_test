using System;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IProjectRepository : IBaseRepository<Project>
	{
		Task<List<Project>> GetProjectWithClientAndUser();
	}
}

