using Domain.Enums;
using Microsoft.AspNetCore.Identity;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class User : IdentityUser
    {
        public string Name { get; set; }

        [Required(ErrorMessage = "User Type is required")]
        public UserType Type { get; set; }

        public ICollection<Project> Projects { get; set; }
    }
}
