using Application.Repositories;
using Domain.Common;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Repositories
{
    public class BaseRepository<T> : IBaseRepository<T> where T : BaseEntity
    {
        protected readonly DataContext _context;

        public BaseRepository(DataContext context)
        {
            _context = context;
        }

        public Task Create(T entity)
        {
            _context.Set<T>().Add(entity);
            return _context.SaveChangesAsync();
        }

        public Task Delete(T entity)
        {
            _context.Remove(entity);
            return _context.SaveChangesAsync();
        }

        public Task<T?> Get(Guid id)
        {
            return _context.Set<T>().FirstOrDefaultAsync(x => x.Id == id);
        }

        public Task<List<T>> GetAll()
        {
            return _context.Set<T>().ToListAsync();
        }

        public Task Update(T entity)
        {
            _context.Update(entity);
            return _context.SaveChangesAsync();
        }
    }
}


