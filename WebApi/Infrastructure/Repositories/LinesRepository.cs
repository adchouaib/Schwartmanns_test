using System;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
	public class LinesRepository : BaseRepository<Lines>, ILinesRepository
    {
        public LinesRepository(DataContext context) : base(context) { }
    }
}

