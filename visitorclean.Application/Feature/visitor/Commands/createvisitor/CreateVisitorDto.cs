using System;
using System.Diagnostics.Contracts;

namespace visitorclean.Application.Feature.visitor.Commands.createvisitor;

public class CreateVisitorDto
{
    public required string Nom{get;set;}
    public required string Email{get;set;}
    public required string Password{get;set;}
    public DateTime CreatedAT{get;set;}=DateTime.Now;
}