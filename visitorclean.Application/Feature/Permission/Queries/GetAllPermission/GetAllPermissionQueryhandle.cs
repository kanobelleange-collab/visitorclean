using MediatR;
using visitorclean.Application.Interface;
using visitorclean.Domain.Entities;

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