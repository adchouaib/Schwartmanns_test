using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record Stat(string name, int stat);
    public record ProjectPerClient
    {
        public string clientName { get; init; }
        public int projectcount { get; init; }
    }
}
