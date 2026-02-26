using AutoMapper;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Visite.Commande.CreateVisit;
using visitorclean.Application.Feature.Visite.Commande.DeleteVisit;
using visitorclean.Application.Feature.Visite.Commande.UpdateVisit.UpdateVisitCommand;
using visitorclean.Application.Feature.Visite.Dtos;
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