using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Interface;
using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using visitorclean.Application.Feature.visit.Dto;
using visitorclean.Application.Feature.visit.Commands.createvisit;


namespace visitorclean.Application.Feature.visit.Commands.createvisit;

public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand , VisitDto>
{
    private readonly IVisitRepository _Repo;
    private readonly IMapper _mapper;
    private readonly IPermissionService _permissionService;

    public CreateVisitCommandHandler(IVisitRepository repo ,IMapper mapper,IPermissionService permissionService)
    {
        _Repo=repo;
        _mapper=mapper;
        _permissionService=permissionService;
    }

    public async Task <VisitDto>Handle(CreateVisitCommand request ,CancellationToken cancellationToken)
    {
        var hasPermission = await _permissionService
            .HasPermission(request.UserId, Permissions.CreateVisit);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    
   
         // 1️⃣ Mapper DTO → Entity
        var visit = _mapper.Map<Visit>(request);

    // 2️⃣ Vérification importante
        if (visit.idVisitor == 0)
        throw new Exception("VisitorId obligatoire");

    // 3️⃣ Sauvegarde en base
    

  
         var id = await _Repo.AddAsync(visit);
         visit.Id = id;
        // 4️⃣ Mapper Entity → DTO
         return _mapper.Map<VisitDto>(visit);
       

    }
}