using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
	public class Sheet : BaseEntity
	{
		[Required(ErrorMessage = "Length is required")]
		[Range(1, double.MaxValue, ErrorMessage = "The Length must be a positive number")]
		public double Length { get; set; }

        [Required(ErrorMessage = "Width is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The Width must be a positive number")]
        public double Width { get; set; }

		public Guid JobId { get; set; }
		public Job Job { get; set; }

		public ICollection<Lines> PolyLines { get; set; }
		public ICollection<Circle> Circles { get; set; }
	}
}

