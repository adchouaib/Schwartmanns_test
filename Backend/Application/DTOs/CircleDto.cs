using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Application.DTOs
{
    public record GetCircle(Guid Id, double xPosition, double yPosition, double Radius);
    public record CreateCircle(double xPosition, double yPosition, double Radius, Guid SheetId);
    public record GetCircleProperties
    {
        public double diameter { get; init; }
        public double surfaceArea { get; init; }
        public double circumference { get; init; }

    }
}
