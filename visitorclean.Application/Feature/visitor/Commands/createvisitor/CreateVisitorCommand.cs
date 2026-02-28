using visitorclean.Domain.Entities;
using System;
using MediatR;
using visitorclean.Application.Feature.visitor.Dto;

 namespace visitorclean.Application.Feature.visitor.Commands.createvisitor;

public record CreateVisitorCommand: IRequest<VisitorDto>
{
    public string ?Nom{get;set;}
    public string ?Email{get;set;}
    public string ?Passwordhash{get;set;}
    public DateTime CreatedAT{get;set;}
    public int RoleId{get;set;}
    public int userId{get;set;}
}