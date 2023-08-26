using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.Repositories
{
    public interface IUserRepository
    {
        Task<List<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<User?> GetById(Guid id);
    }
}
