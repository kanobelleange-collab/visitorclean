using visitorclean.Domain.Entities;
using visitorclean.Application.Interface;
using System;
using System.Threading.Tasks;
using AutoMapper;
using MediatR;
using visitorclean.Application.DTOs;
using visitorclean.Application.Feature.visit.Commands.createvisit;


namespace visitorclean.Application.Feature.visit.Commands.createvisit;

public class CreateVisitCommandHandler : IRequestHandler<CreateVisitCommand , VisitDto>
{
    private readonly IVisitRepository _Repo;
    private readonly IMapper _mapper;

    public CreateVisitCommandHandler(IVisitRepository repo ,IMapper mapper)
    {
        _Repo=repo;
        _mapper=mapper;
    }
    public async Task <VisitDto>Handle(CreateVisitCommand request ,CancellationToken cancellationToken)
    {
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