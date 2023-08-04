using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;
using Domain.Enums;

namespace Domain.Entities
{
	public class User : BaseEntity
	{
		[Required(ErrorMessage = "Name is required")]
		[StringLength(30, MinimumLength = 2, ErrorMessage = "Name must be between 2 and 30 characters")]
		public string Name { get; set; }

		[Required(ErrorMessage = "Email is required")]
		[EmailAddress(ErrorMessage = "Invalid email format")]
		[StringLength(100, ErrorMessage = "Email must not exceed 100 characters")]
		public string Email { get; set; }

		[Required(ErrorMessage = "Password is required")]
		[MinLength(8, ErrorMessage = "Password must be at least 8 characters")]
		[DataType(DataType.Password)]
		public string Password { get; set; }

		[Required(ErrorMessage = "User Type is required")]
		public UserType Type { get; set; }

		public ICollection<Project> Projects { get; set; }
	}
}

