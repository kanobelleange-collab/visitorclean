using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.Visite.Interfaces;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Visite.Commande.DeleteVisit;
namespace visitorclean.Application.Feature.Visite.Commande.DeleteVisit.DeleteVisitHandler;
public class DeleteVisitHandler:IRequestHandler<DeleteVisitCommand, Visit>
{
    private readonly IVisitRepository _repository;
    private readonly IMapper _mapper;
    public DeleteVisitHandler(IVisitRepository repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }
    public async Task<Visit>Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
    {
        var visit = await _repository.GetByIdAsync(request.Id);
        
        if (visit == null)
            throw new KeyNotFoundException("Visiteur non trouvé");
        await _repository.DeleteAsync(request.Id);

        return _mapper.Map<Visit>(visit);
    }
}