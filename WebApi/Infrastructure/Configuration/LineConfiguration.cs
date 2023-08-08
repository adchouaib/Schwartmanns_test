using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
	public class LineConfiguration : IEntityTypeConfiguration<Lines>
	{
        public void Configure(EntityTypeBuilder<Lines> builder)
        {
            Lines capLine = new Lines
            {
                Id = new Guid("6fbf3f83-42d3-40f8-888d-cc5480b4933c"),
                SheetId = new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"),
                xPosition = 10,
                yPosition = 10,
                Bulge = 10,
            };

            builder.HasData(capLine);
        }
    }
}

