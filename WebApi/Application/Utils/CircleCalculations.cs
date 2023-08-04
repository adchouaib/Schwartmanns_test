using System;
namespace Application.Utils
{
	public class CircleCalculations
	{
		public static double CalculateSurfaceArea(double radius) => Math.PI * Math.Pow(radius, 2);

		public static double CalculateCircumference(double radius) => 2 * Math.PI * radius;

		public static double CalculateDiameter(double radius) => 2 * radius;
    }
}

