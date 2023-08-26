using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly DataContext _context;
        public UserRepository(DataContext context)
        {
            _context = context;
        }

        public Task<List<User>> GetAll()
        {
            return _context
                .Users
                .ToListAsync();
        }

        public Task<User?> GetByEmail(string email)
        {
            return _context
                .Users
                .Where(user => user.Email == email)
                .FirstOrDefaultAsync();
        }

        public Task<User?> GetById(Guid id)
        {
            return _context
                .Users
                .Where(user => user.Id == id.ToString())
                .FirstOrDefaultAsync();
        }
    }
}


