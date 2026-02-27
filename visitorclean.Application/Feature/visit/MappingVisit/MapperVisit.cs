using AutoMapper;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Feature.visit.Commands.deletevisit;
using visitorclean.Application.Feature.visit.Commands.updatevisit;
using visitorclean.Application.Feature.visit.Dto;
namespace visitorclean.Application.Feature.visit.MappingVisit;
public class MapperVisit : Profile
{
    public MapperVisit()
    {
        CreateMap<VisitDto, Visit>().ReverseMap();
        CreateMap<CreateVisitCommand, Visit>();
        CreateMap<UpdateVisitCommand, Visit>();  
        CreateMap<UpdateVisitCommand, VisitDto>();   
        CreateMap<DeleteVisitCommand, VisitDto>(); 
    }
}