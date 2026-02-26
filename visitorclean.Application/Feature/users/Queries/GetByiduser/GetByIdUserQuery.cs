using System;
using visitorclean.Domain.Entities;

using visitorclean.Application.Feature.users.Dto;
using MediatR;
using System.Net;


namespace visitorclean.Application.Feature.users.Queries.GetByiduser;

public record GetByIdUserQuery:IRequest<Users>
{
    public int Id{get;set;}
    public GetByIdUserQuery(int id)
    {
        Id=id;
    }
}
