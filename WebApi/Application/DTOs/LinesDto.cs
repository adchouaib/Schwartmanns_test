using System;
namespace Application.DTOs
{
	public record GetLines(Guid Id, double xPosition, double yPosition, double Bulge);
	public record CreateLines(double xPosition, double yPosition, double Bulge, Guid SheetId);
}

