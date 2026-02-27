using MediatR;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Domain.Entities;
namespace visitorclean.Application.Feature.visit.Queries.GetAllVisit;
public record GetAllVisitQuery:IRequest<List<VisitDto>>{}