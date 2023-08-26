using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record Login(string email, string password);
    public record JwtToken(string token, string name);
}