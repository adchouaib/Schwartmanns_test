using System;
using Application.Repositories;
using Domain.Entities;
using Infrastructure.Context;

namespace Infrastructure.Repositories
{
	public class CircleRepository : BaseRepository<Circle>, ICircleRepository
    {
        public CircleRepository(DataContext context) : base(context) { }
    }
}

