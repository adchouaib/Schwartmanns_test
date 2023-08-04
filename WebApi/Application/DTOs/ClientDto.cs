using System;
namespace Application.DTOs
{
	public record GetClient(Guid Id, string Name, string Phone, string Address);
	public record CreateClient(string Name, string Phone, string Address);
}

