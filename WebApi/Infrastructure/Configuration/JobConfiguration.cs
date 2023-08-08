using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class JobConfiguration : IEntityTypeConfiguration<Job>
    {
        public void Configure(EntityTypeBuilder<Job> builder)
        {
            Job capJob = new Job
            {
                Id = new Guid("c42ef423-2dd0-4b12-a05c-36cebcbdc114"),
                ProjectId = new Guid("d413951c-0a53-4531-adf5-a07838d7b966"),
                MaterialId = 2,
            };

            builder.HasData(capJob);
        }
    }
}

