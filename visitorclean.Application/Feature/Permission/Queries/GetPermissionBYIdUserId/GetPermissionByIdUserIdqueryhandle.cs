using MediatR;
using visitorclean.Application.Interface;

public class GetPermissionsByUserIdQueryHandler 
    : IRequestHandler<GetPermissionsByUserIdQuery, List<string>>
{
    private readonly IPermissionRepository _repository;

    public GetPermissionsByUserIdQueryHandler(IPermissionRepository repository)
    {
        _repository = repository;
    }

    public async Task<List<string>> Handle(
        GetPermissionsByUserIdQuery request,
        CancellationToken cancellationToken)
    {
        return await _repository.GetPermissionsByUserId(request.UserId);
    }
}