using visitorclean.Domain.Entities;
using System;
using visitorclean.Domain.Enums;
namespace visitorclean.Application.Feature.visit.Commands.CreateVisitDto;

public class CreateVisitDto
{
    public  required string? motif{get;set;}

    public required DateTime datevisit{get;set;}

    public required Service_A_Visiter Service_A_Visiter{get; set;}

    public required int idVisitor{get;set;}




}
