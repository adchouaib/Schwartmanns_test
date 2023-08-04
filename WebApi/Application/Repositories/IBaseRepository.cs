using System;
using Domain.Common;

namespace Application.Repositories
{
	public interface IBaseRepository<T> where T : BaseEntity
	{
		Task Create(T entity);
        Task Update(T entity);
        Task Delete(T entity);
		Task<T?> Get(Guid id);
		Task<List<T>> GetAll();
	}
}

