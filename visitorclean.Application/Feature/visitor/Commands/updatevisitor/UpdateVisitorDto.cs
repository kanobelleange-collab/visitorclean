using visitorclean.Application.DTOs;
using System;

namespace visitorclean.Application.Feature.visitor.Commands.updatevisitor;

public class UpdateVisitorDto
{
    //return l'ancien id du visiteur
    
    public required int Id{get;set;}

    public required string Nom{get;set;}

    public required string Email{get;set;}



}