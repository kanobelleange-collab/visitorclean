using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Interface;
using System.Threading;
using System.Threading.Tasks;
using visitorclean.Application.Service;
using AutoMapper;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using visitorclean.Application.DTOs;

namespace visitorclean.Application.Feature.visitor.Commands.createvisitor;

    public class CreateVisitorCommandHandler : IRequestHandler<CreateVisitorCommand, VisitorDto>
    {
        private readonly IVisitorRepository _repo;
        private readonly ISecurityService _Service;
        private readonly IMapper _mapper;

        public CreateVisitorCommandHandler(IVisitorRepository repository, ISecurityService Service,IMapper mapper)
        {
            _repo = repository;
            _Service = Service;
            _mapper=mapper;
        }

        public async Task<VisitorDto> Handle(CreateVisitorCommand request, CancellationToken cancellationToken)
        {
            // Hasher le mot de passe
            var hashedPassword = _Service.HashPassword(request.password);

            // Créer le visiteur
            var visitor = new Visitor(request.nom, request.email, request.password, request.createdAT);

            // Ajouter en base
             await _repo.AddAsync(visitor);
            

            var visitorDto=_mapper.Map<VisitorDto>(visitor);
            return visitorDto;
            
        }
    }

