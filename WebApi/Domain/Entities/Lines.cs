using System;
using System.ComponentModel.DataAnnotations;
using Domain.Common;

namespace Domain.Entities
{
	public class Lines : BaseEntity
	{
        [Required(ErrorMessage = "xPosition is required")]
        public double xPosition { get; set; }

        [Required(ErrorMessage = "yPosition is required")]
        public double yPosition { get; set; }

        public double Bulge { get; set; }

        public Guid SheetId { get; set; }
        public Sheet Sheet { get; set; }
    }
}

