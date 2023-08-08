using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
    public class ProjectConfiguration : IEntityTypeConfiguration<Project>
    {
        public void Configure(EntityTypeBuilder<Project> builder)
        {
            Project capProject = new Project
            {
                Id = new Guid("d413951c-0a53-4531-adf5-a07838d7b966"),
                UserId = "1e8356cb-a0fd-4859-b483-9e0fd7489afb",
                ClientId = new Guid("eb67c695-d666-4a5e-81b8-fd486d44672b"),
                FileName = "cap.pdf",
                FilePath = "capProjects/cap.pdf",
                Name = "Création d'un dashboard",
            };

            Project capProject2 = new Project
            {
                Id = new Guid("1829a532-fcec-45a2-93b8-8bbb7a8eb9c0"),
                UserId = "1e8356cb-a0fd-4859-b483-9e0fd7489afb",
                ClientId = new Guid("eb67c695-d666-4a5e-81b8-fd486d44672b"),
                FileName = "cap2.pdf",
                FilePath = "capProjects/cap2.pdf",
                Name = "migration d'une application vers .Net Core",
            };

            Project algoProject = new Project
            {
                Id = new Guid("27f07d89-745b-441c-9cf1-d9559f5294ed"),
                UserId = "1e8356cb-a0fd-4859-b483-9e0fd7489afb",
                ClientId = new Guid("dce52084-ed68-4f9e-85f6-fdf5e20a45ad"),
                FileName = "algo.pdf",
                FilePath = "algoProjects/algo.pdf",
                Name = "mise en place d'une architecture microservice",
            };

            Project novecProject = new Project
            {
                Id = new Guid("c470b265-87c9-4447-a817-8269f052bc6c"),
                UserId = "1e8356cb-a0fd-4859-b483-9e0fd7489afb",
                ClientId = new Guid("84e8668b-7a49-4283-96aa-73b871f6e679"),
                FileName = "novec.pdf",
                FilePath = "novecProjects/novec.pdf",
                Name = "migration vers dotnet core",
            };

            builder.HasData(capProject, capProject2, algoProject, novecProject);
        }
    }
}

