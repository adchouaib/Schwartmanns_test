using System;
using Application.DTOs;
using AutoMapper;
using Domain.Entities;

namespace Application.Mappers
{
	public class UserMapper : Profile
	{
		public UserMapper()
		{
			CreateMap<CreateUser, User>();
			CreateMap<User, GetUser>();
		}
	}
}

