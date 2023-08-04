using System;
namespace Application.DTOs
{
	public record GetProject(Guid Id, string Name, string FileName, string FilePath, GetUser User, GetClient Client);
    public record CreateProject(string Name, string FileName, string FilePath, Guid UserId, Guid ClientId);
}

