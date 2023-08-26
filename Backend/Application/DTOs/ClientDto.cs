using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetClient(Guid Id, string Name, string Phone, string Address);
    public record CreateClient(string Name, string Phone, string Address);
}
