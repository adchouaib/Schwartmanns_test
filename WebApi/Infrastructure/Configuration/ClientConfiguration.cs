using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
	public class ClientConfiguration : IEntityTypeConfiguration<Client>
	{
        public void Configure(EntityTypeBuilder<Client> builder)
        {
            Client capgemini = new Client
            {
                Id = new Guid("eb67c695-d666-4a5e-81b8-fd486d44672b"),
                Name = "Capgemini",
                Address = "Rabat Technopolis",
                Phone = "0666666666",
            };

            Client novec = new Client
            {
                Id = new Guid("84e8668b-7a49-4283-96aa-73b871f6e679"),
                Name = "novec",
                Address = "Rabat Technopolis",
                Phone = "0666666666",
            };

            Client algoconsulting = new Client
            {
                Id = new Guid("dce52084-ed68-4f9e-85f6-fdf5e20a45ad"),
                Name = "ALGO Consulting",
                Address = "Rabat Souissi",
                Phone = "0666666666",
            };

            Client intelcap = new Client
            {
                Id = new Guid("76ca6169-5587-4204-be0e-f45f9cb0288d"),
                Name = "intelcap",
                Address = "Rabat Agdal",
                Phone = "0666666666",
            };

            builder.HasData(capgemini, novec, algoconsulting, intelcap);
        }
    }
}

