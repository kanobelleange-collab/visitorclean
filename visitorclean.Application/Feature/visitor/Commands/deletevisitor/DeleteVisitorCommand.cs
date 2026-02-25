using visitorclean.Domain.Entities;
using MediatR;
using System;
using System.Net;
using visitorclean.Application.Feature.visitor.Interface;

namespace visitorclean.Application.Feature.visitor.Commands.deletevisitor;
public record DeleteVisitorCommand: IRequest<bool>
{
    public int Id{get;set;}

    public DeleteVisitorCommand(int id)
    {
        Id=id;
    }
}