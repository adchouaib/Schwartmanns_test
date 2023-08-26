using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetSheet(Guid Id, double Length, double Width);
    public record CreateSheet(double Length, double Width, Guid JobId);
    public record GetSheetComponents(Guid Id, double Length, double Width, ICollection<GetLines> PolyLines, ICollection<GetCircle> Circles);
}
