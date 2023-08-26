using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetJob(Guid Id, int MaterialId);
    public record CreateJob(int MaterialId, Guid ProjectId);
}
