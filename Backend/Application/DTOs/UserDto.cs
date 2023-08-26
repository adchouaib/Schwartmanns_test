using Domain.Enums;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetUser(Guid Id, string Name, string Email);
    public record CreateUser(string Name, string Email, string Password, UserType Type);
    public record DeleteUser(Guid Id);
    public record UpdatePassword(Guid Id, string currentPassword, string newPassword);
}
