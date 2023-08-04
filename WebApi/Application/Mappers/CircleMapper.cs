using System;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class CircleMapper : Profile
	{
		public CircleMapper()
		{
			CreateMap<CreateCircle, Circle>();
			CreateMap<Circle, GetCircle>();
		}
	}
}

