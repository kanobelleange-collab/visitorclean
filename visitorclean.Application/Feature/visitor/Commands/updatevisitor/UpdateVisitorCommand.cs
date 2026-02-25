using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visitor.Interface;
using System.Net;
using visitorclean.Application.Feature.visitor.Dto;

namespace visitorclean.Application.Feature.visitor.Commands.updatevisitor;

public record UpdateVisitorCommand: IRequest<VisitorDto>
{
    public  int Id{get;set;}
    public required  string Nom{get;set;}
    public required string Email{get;set;}
    public required string Password{get;set;}

}
