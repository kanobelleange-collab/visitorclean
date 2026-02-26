using System;
using System.Net;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.users.Dto;
using MediatR;


namespace visitorclean.Application.Feature.users.Queries.Getalluser;

public record GetAllUserQuery (): IRequest<List<UserDto>>
{
    
}