using System;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class ClientMapper : Profile
	{
		public ClientMapper()
		{
			CreateMap<CreateClient, Client>();
			CreateMap<Client, GetClient>();
		}
	}
}

