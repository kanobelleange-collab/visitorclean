using AutoMapper;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Feature.visit.Commands.updatevisit;
using visitorclean.Application.Feature.visit.Commands.CreateVisitDto;
using visitorclean.Application.Feature.visit.Dto;
using System.Security;
using System.Runtime.InteropServices;
using System.Runtime;

namespace visitorclean.Application.Feature.visit.Mapping;


public class VisitMapping : Profile
{

        public VisitMapping()
    {
        
         CreateMap<Visit ,VisitDto>();
        //Dto en command
        CreateMap<CreateVisitDto ,CreateVisitCommand>();
        CreateMap<UpdateVisitDto ,UpdateVisitCommand>();
        CreateMap<CreateVisitDto, Visit>();
        CreateMap<CreateVisitCommand, Visit>();
        CreateMap<Visit, VisitDto>();
    }


}
