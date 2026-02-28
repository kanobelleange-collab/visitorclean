using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visitor.Interface;
using System.Threading;
using System.Threading.Tasks;
using visitorclean.Application.Service.Interface;
using AutoMapper;
using Microsoft.VisualBasic;
using System.Reflection.Metadata.Ecma335;
using visitorclean.Application.Feature.visitor.Dto;
using visitorclean.Application.Common;



namespace visitorclean.Application.Feature.visitor.Commands.createvisitor;

    public class CreateVisitorCommandHandler : IRequestHandler<CreateVisitorCommand, VisitorDto>
    {
        private readonly IVisitorRepository _repo;
        private readonly ISecurityService _Service;
        private readonly IMapper _mapper;
        private readonly IPermissionService _permissionService;

        public CreateVisitorCommandHandler(IVisitorRepository repository, ISecurityService Service,IMapper mapper,IPermissionService permissionService)
        {
            _repo = repository;
            _Service = Service;
            _mapper=mapper;
            _permissionService=permissionService;
        }
    public async Task <VisitorDto>Handle(CreateVisitorCommand request ,CancellationToken cancellationToken)
    {
       var userId = request.userId;

var hasPermission = await _permissionService.HasPermission(userId, "Visitor.Create");

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    
       
            // Hasher le mot de passe
            var hashedPassword = _Service.HashPassword(request.Passwordhash);

            // Créer le visiteur
            var visitor = new Visitor(request.Nom, request.Email, request.Passwordhash, request.CreatedAT);

            // Ajouter en base
             await _repo.AddAsync(visitor);
            

            var visitorDto=_mapper.Map<VisitorDto>(visitor);
            return visitorDto;
            
        }
    }

