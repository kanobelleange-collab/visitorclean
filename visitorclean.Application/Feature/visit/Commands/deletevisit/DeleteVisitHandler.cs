using MediatR;
using AutoMapper;
using visitorclean.Application.Feature.visit.Interface;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visit.Commands.deletevisit;
using visitorclean.Application.Common;
using visitorclean.Application.Feature.Permission.Interface;
using visitorclean.Application.Service.Interface;
namespace visitorclean.Application.Feature.visit.Commands.deletevisit.DeleteVisitHandler;
public class DeleteVisitHandler:IRequestHandler<DeleteVisitCommand, Visit>
{
    private readonly IVisitRepository _repository;
    private readonly IMapper _mapper;
    private readonly IPermissionService _permissionService;
    public DeleteVisitHandler(IVisitRepository repository, IMapper mapper,IPermissionService permissionService)
    {
        _repository=repository;
        _mapper=mapper;
        _permissionService=permissionService;
    }
    public async Task<Visit>Handle(DeleteVisitCommand request, CancellationToken cancellationToken)
    {

            var hasPermission = await _permissionService
            .HasPermission(request.UserId, AppPermission.DeleteVisit);

        if (!hasPermission)
            throw new UnauthorizedAccessException();
    

        var visit = await _repository.GetByIdAsync(request.Id);
        
        if (visit == null)
            throw new KeyNotFoundException("Visiteur non trouvé");
        await _repository.DeleteAsync(request.Id);

        return _mapper.Map<Visit>(visit);
    }
}