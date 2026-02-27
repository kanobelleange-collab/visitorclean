using MediatR;
using visitorclean.Application.Feature.Permission.Interface;
using visitorclean.Domain.Entities;
using  visitorclean.Application.Permission.Queries.GetAllPermission.GetAllPermissionsQuery;
namespace visitorclean.Application.Feature.Permission.Queries.GetAllPermission.GetAllPermissionsQueryHandler ;
public class GetAllPermissionsQueryHandler 
    : IRequestHandler<GetAllPermissionsQuery, List<Permissions>>
{
    private readonly IPermissionRepository _repo;

    public GetAllPermissionsQueryHandler(IPermissionRepository repo)
    {
        _repo = repo;
    }

    public async Task<List<Permissions>> Handle(
        GetAllPermissionsQuery request,
        CancellationToken cancellationToken)
    {
        return await _repo.GetAllAsync();
    }
}