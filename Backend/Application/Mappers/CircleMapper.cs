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
    public class CircleMapper : Profile
    {
        public CircleMapper()
        {
            CreateMap<CreateCircle, Circle>();
            CreateMap<Circle, GetCircle>();
        }
    }
}
