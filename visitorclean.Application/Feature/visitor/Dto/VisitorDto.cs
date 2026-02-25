using visitorclean.Domain.Entities;
using System;

namespace visitorclean.Application.Feature.visitor.Dto;
public class VisitorDto
{
    public required string Nom{get;set;}=string.Empty;
    public required string Email{get;set;}=string .Empty;
    public required string Password{get;set;}=string.Empty;
}