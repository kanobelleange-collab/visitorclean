using System;
using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.users.Dto;
using MediatR;
using System.Net;


namespace visitorclean.Application.Feature.users.Queries.GetByiduser;

public record GetByIdUserQuery:IRequest<UserDto?>
{
    public int Id{get;set;}
    public GetByIdUserQuery(int id)
    {
        Id=id;
    }
}
