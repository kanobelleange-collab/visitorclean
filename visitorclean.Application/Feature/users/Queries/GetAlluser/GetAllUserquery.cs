using System;
using System.Net;
using visitorclean.Domain.Entities;
using visitorclean.Application.DTOs;
using MediatR;


namespace visitorclean.Application.Feature.user.Queries.Getalluser;

public record GetAllUserQuery (): IRequest<List<UserDto>>
{
    
}