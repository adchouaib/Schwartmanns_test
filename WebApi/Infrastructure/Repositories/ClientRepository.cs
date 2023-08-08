using System;
using Application.DTOs;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Repositories
{
	public class ClientRepository : BaseRepository<Client>, IClientRepository
    {
        public ClientRepository(DataContext context) : base(context) { }

        public Task<List<ProjectPerClient>> ProjectPerClients()
        {
            return _context.Clients
                .GroupJoin(
                    _context.Projects,
                    client => client.Id,
                    project => project.ClientId,
                    (client, projects) => new ProjectPerClient
                    {
                        clientName = client.Name,
                        projectcount = projects.Count(),
                    })
                .ToListAsync();
        }
    }
}

