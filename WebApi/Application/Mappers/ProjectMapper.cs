using System;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class ProjectMapper : Profile
	{ 
		public ProjectMapper()
		{
            CreateMap<CreateProject, Project>();
            CreateMap<Project, GetProject>()
				.ForMember(dest => dest.Client, opt => opt.MapFrom(src => src.Client));
        }
	}
}

