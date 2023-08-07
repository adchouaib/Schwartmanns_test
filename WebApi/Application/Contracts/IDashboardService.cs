using System;
using Application.DTOs;

namespace Application.Contracts
{
	public interface IDashboardService
	{
		Task<List<Stat>> getCountEntities();
	}
}

