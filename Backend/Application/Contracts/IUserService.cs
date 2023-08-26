using Application.DTOs;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
        Task<bool> UpdatePassword(UpdatePassword updatePassword);
    }
}
