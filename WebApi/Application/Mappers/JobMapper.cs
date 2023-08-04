using System;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

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

