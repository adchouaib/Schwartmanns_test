using System;
using Domain.Entities;
using System.Threading.Tasks;
using Application.DTOs;

namespace Application.Contracts
{
    public interface IUserService
    {
        Task<List<User>> GetAll();
        Task<User?> GetByEmail(string email);
        Task<User?> GetById(Guid id);
        Task CreateUser(CreateUser user);
        Task<JwtToken> Login(Login login);
        Task<bool> DeleteUser(DeleteUser deleteUser);
    }
}

