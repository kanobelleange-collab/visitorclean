using MediatR;
using System;
using AutoMapper;
using System.Threading;
using System.Threading.Tasks;
using visitorclean.Application.Feature.Visite.Dtos;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.Visite.Interfaces;
using visitorclean.Application.Feature.Visite.Commande.CreateVisit;
namespace visitorclean.Application.Feauture.Visite.Commandes.Handler.VisitHandler;
    public class CreateVisitHandler : IRequestHandler<CreateVisitCommand, VisitDto>
    {
         private readonly IVisitRepository  _repository;
         private readonly IMapper _mapper;

        public CreateVisitHandler(IVisitRepository repository, IMapper mapper)
        {
            _repository = repository;
            _mapper = mapper;
        }

        public async Task<VisitDto> Handle(CreateVisitCommand request, CancellationToken cancellationToken)
        {
             var hasPermission = await _permissionService
            .HasPermission(request.UserId, AppPermission.CreateUser);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    

            var visit= _mapper.Map<Visit>(request);
             await _repository.AddAsync(visit);
             return _mapper.Map<VisitDto>(visit);
            
        }
    }