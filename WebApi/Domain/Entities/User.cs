using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Enums;
using Microsoft.AspNetCore.Identity;

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

