using System;
using Domain.Entities;
using Microsoft.EntityFrameworkCore;

namespace Infrastructure.Context
{
	public class DataContext : DbContext
	{
		public DbSet<User> Users { get; set; }
		public DbSet<Project> Projects { get; set; }
		public DbSet<Client> Clients { get; set; }
		public DbSet<Job> Jobs { get; set; }
		public DbSet<Sheet> Sheets { get; set; }
		public DbSet<Circle> Circles { get; set; }
		public DbSet<Lines> PolyLines { get; set; }

		public DataContext() { }
		public DataContext(DbContextOptions<DataContext> options) : base(options) { }

		protected override void OnModelCreating(ModelBuilder builder)
		{
			builder.Entity<Project>()
				.HasOne(p => p.User)
				.WithMany(u => u.Projects)
				.HasForeignKey(p => p.UserId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Project>()
				.HasOne(p => p.Client)
				.WithMany(c => c.Projects)
				.HasForeignKey(p => p.ClientId)
				.OnDelete(DeleteBehavior.Restrict);

			builder.Entity<Project>()
				.HasMany(p => p.Jobs)
				.WithOne(j => j.Project)
				.HasForeignKey(j => j.ProjectId);

			builder.Entity<Job>()
				.HasMany(j => j.Sheets)
				.WithOne(s => s.Job)
				.HasForeignKey(s => s.JobId);

			builder.Entity<Sheet>()
				.HasMany(s => s.PolyLines)
				.WithOne(p => p.Sheet)
				.HasForeignKey(p => p.SheetId);

            builder.Entity<Sheet>()
                .HasMany(s => s.Circles)
                .WithOne(c => c.Sheet)
                .HasForeignKey(c => c.SheetId);

            base.OnModelCreating(builder);
		}
	}
}

