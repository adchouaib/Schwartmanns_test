using System;
using Domain.Entities;

namespace Application.DTOs
{
	public record GetJob(Guid Id, int MaterialId);
	public record CreateJob(int MaterialId, Guid ProjectId);
}

