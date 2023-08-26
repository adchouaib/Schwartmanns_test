using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetLines(Guid Id, double xPosition, double yPosition, double Bulge);
    public record CreateLines(double xPosition, double yPosition, double Bulge, Guid SheetId);
}
