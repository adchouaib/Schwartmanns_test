using System;
namespace Application.DTOs
{
	public record Login(string email, string password);
	public record JwtToken(string token, string name);
}

