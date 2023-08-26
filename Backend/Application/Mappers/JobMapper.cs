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
    public class JobMapper : Profile
    {
        public JobMapper()
        {
            CreateMap<CreateJob, Job>();
            CreateMap<Job, GetJob>();
        }
    }
}
