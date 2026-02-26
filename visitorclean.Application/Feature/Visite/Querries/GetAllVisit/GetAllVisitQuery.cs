using MediatR;
using visitorclean.Application.Feature.Visite.Dtos;
using visitorclean.Domain.Entities;
namespace visitorclean.Application.Feature.Visite.Querries.GetAllVisit;
public record GetAllVisitQuery:IRequest<List<VisitDto>>{}