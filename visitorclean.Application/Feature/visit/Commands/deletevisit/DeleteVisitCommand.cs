using MediatR;
using visitorclean.Domain.Entities;
namespace visitorclean.Application.Feature.visit.Commands.deletevisit;
public record DeleteVisitCommand(int Id,int UserId):IRequest<Visit>{}