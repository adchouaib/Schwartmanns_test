using System;
using Domain.Entities;

namespace Application.Repositories
{
	public interface IUserRepository
	{
        Task<List<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<User?> GetById(Guid id);
    }
}

