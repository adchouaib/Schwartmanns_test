using System;
using Domain.Entities;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore.Metadata.Builders;

namespace Infrastructure.Configuration
{
	public class UserConfiguration : IEntityTypeConfiguration<User>
	{
        public void Configure(EntityTypeBuilder<User> builder)
        {
            var email = "admin@gmail.com";
            var username = "admin";
            var adminUser = new User
            {
                Id = new Guid("1e8356cb-a0fd-4859-b483-9e0fd7489afb").ToString(),
                UserName = username,
                NormalizedUserName = username.Trim().ToUpper(),
                Email = email,
                NormalizedEmail = email.Trim().ToUpper(),
                Name = "admin",
                Type = Domain.Enums.UserType.Admin,
            };
          

            var passwordHasher = new PasswordHasher<User>();
            adminUser.PasswordHash = passwordHasher.HashPassword(adminUser, "Admin123@");

            builder.HasData(adminUser);
        }
    }
}

