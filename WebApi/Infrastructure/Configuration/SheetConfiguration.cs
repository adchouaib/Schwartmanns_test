using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
	public class SheetConfiguration : IEntityTypeConfiguration<Sheet>
	{
        public void Configure(EntityTypeBuilder<Sheet> builder)
        {
            Sheet capSheet1 = new Sheet
            {
                Id = new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"),
                JobId = new Guid("c42ef423-2dd0-4b12-a05c-36cebcbdc114"),
                Length = 10,
                Width = 10,
            };

            Sheet capSheet2 = new Sheet
            {
                Id = new Guid("47e5baa6-ac3d-4c5b-be21-4b1d3c32c7bd"),
                JobId = new Guid("c42ef423-2dd0-4b12-a05c-36cebcbdc114"),
                Length = 12,
                Width = 12,
            };

            builder.HasData(capSheet1, capSheet2);
        }
    }
}

