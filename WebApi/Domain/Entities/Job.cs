using System;
using Domain.Common;

namespace Domain.Entities
{
	public class Job : BaseEntity
	{
		public int MaterialId { get; set; }

		public Guid ProjectId { get; set; }
		public Project Project { get; set; }

		public ICollection<Sheet> Sheets { get; set; }
	}
}

