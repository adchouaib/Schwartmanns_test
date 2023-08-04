using System;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class LinesMapper : Profile
	{
		public LinesMapper()
		{
			CreateMap<CreateLines, Lines>();
			CreateMap<Lines, GetLines>();
		}
	}
}

