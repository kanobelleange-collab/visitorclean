using AutoMapper;
using  visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visitor.Commands.createvisitor;
using visitorclean.Application.Feature.visitor.Commands.deletevisitor;
using visitorclean.Application.Feature.visitor.Commands.updatevisitor;
using visitorclean.Application.Feature.visitor.Dto;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime;

namespace visitorclean.Feature.visitor.Mapping;

public class VisitorMapping : Profile
{
    public VisitorMapping()
    {

         CreateMap<Visitor ,VisitorDto>();
         CreateMap<CreateVisitorCommand, Visitor>();
         CreateMap<CreateVisitorCommand, VisitorDto>();
         CreateMap<UpdateVisitorCommand, Visitor>();
         CreateMap<UpdateVisitorCommand, VisitorDto>();
         CreateMap<CreateVisitorDto, CreateVisitorCommand>();

    }
    
}