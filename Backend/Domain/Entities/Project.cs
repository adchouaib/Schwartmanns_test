using Domain.Common;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Domain.Entities
{
    public class Project : BaseEntity
    {
        [Required(ErrorMessage = "Name is required")]
        public string Name { get; set; }

        public string FileName { get; set; }
        public string FilePath { get; set; }

        public string UserId { get; set; }
        public User User { get; set; }

        public Guid ClientId { get; set; }
        public Client Client { get; set; }

        public ICollection<Job> Jobs { get; set; }
    }
}
