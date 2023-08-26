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
    public class LinesMapper : Profile
    {
        public LinesMapper()
        {
            CreateMap<CreateLines, Lines>();
            CreateMap<Lines, GetLines>();
        }
    }
}
