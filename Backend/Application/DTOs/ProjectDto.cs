using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetProject(Guid Id, string Name, string FileName, string FilePath, GetUser User, GetClient Client);
    public record CreateProject(string Name, string FileName, string FilePath, Guid UserId, Guid ClientId);
}
