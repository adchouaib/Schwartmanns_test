using Domain.Common;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
