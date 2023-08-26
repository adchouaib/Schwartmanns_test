using Domain.Entities;
using Microsoft.EntityFrameworkCore.Metadata.Builders;
using Microsoft.EntityFrameworkCore;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Infrastructure.Configuration
{
    public class CircleConfiguration : IEntityTypeConfiguration<Circle>
    {
        public void Configure(EntityTypeBuilder<Circle> builder)
        {
            Circle capCircle1 = new Circle
            {
                Id = new Guid("00c6a184-47f2-4b75-947c-415ee97445cf"),
                SheetId = new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"),
                Radius = 10,
                xPosition = 0,
                yPosition = 1,
            };

            Circle capCircle2 = new Circle
            {
                Id = new Guid("0131f75d-b99c-4f88-8219-b7deed04b118"),
                SheetId = new Guid("448d661f-f1ea-47d8-9080-ef060a5f5bcd"),
                Radius = 20,
                xPosition = 12,
                yPosition = 1,
            };

            builder.HasData(capCircle1, capCircle2);
        }
    }
}
