using visitorclean.Domain.Entities;
using System;
using MediatR;
using visitorclean.Application.DTOs;

 namespace visitorclean.Application.Feature.visitor.Commands.createvisitor;

public record CreateVisitorCommand(string nom,string email,string password,DateTime createdAT):IRequest<VisitorDto>;