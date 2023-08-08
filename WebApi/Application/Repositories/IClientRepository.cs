using System;
using Application.DTOs;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IClientRepository : IBaseRepository<Client>
	{
		Task<List<ProjectPerClient>> ProjectPerClients();
	}
}

