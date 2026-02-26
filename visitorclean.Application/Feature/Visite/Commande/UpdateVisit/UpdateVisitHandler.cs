using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Visite.Dtos;
using visitorclean.Application.Feature.Visite.Interfaces;
using visitorclean.Application.Feature.Visite.Commande.UpdateVisit.UpdateVisitCommand;
namespace visitorclean.Application.Feauture.Visite.Commandes.Handler.VisitHandler;
    public class UpdateVisitHandler : IRequestHandler<UpdateVisitCommand, VisitDto?>
    {
         private readonly IVisitRepository  _repository;
         private readonly IMapper _mapper;

        public UpdateVisitHandler(IVisitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VisitDto?> Handle(UpdateVisitCommand request, CancellationToken cancellationToken)
        {
       var visit=_mapper.Map<Visit>(request);
       return await _repository.UpdateAsync(visit);
            
        }
    }