using MediatR;
using visitorclean.Domain.Entities;
namespace visitorclean.Application.Feature.Visite.Commande.DeleteVisit;
public record DeleteVisitCommand(int Id):IRequest<Visit>{}