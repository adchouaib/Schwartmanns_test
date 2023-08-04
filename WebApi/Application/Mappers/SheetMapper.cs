using System;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class SheetMapper : Profile
	{
		public SheetMapper()
		{
			CreateMap<CreateSheet, Sheet>();
			CreateMap<Sheet, GetSheet>();
			CreateMap<Sheet, GetSheetComponents>();
		}
	}
}

