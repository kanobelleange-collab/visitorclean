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
        //Entities en dto
        CreateMap<Visitor ,VisitorDto>();
        //Dto en command
        CreateMap<CreateVisitorDto ,CreateVisitorCommand>();
        CreateMap<UpdateVisitorDto ,UpdateVisitorCommand>();
        


    }
    
}