using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
	public class Circle : BaseEntity
	{
        [Required(ErrorMessage = "xPosition is required")]
        public double xPosition { get; set; }

        [Required(ErrorMessage = "yPosition is required")]
        public double yPosition { get; set; }

        [Required(ErrorMessage = "Radius is required")]
        [Range(1, double.MaxValue, ErrorMessage = "The Radius must be a positive number")]
        public double Radius { get; set; }

        public Guid SheetId { get; set; }
        public Sheet Sheet { get; set; }
    }
}

