using Application.DTOs;
using AutoMapper;
using Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
