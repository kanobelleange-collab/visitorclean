using System;
using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.users.Queries.GetByiduser;
using visitorclean.Application.Feature.users.Interface;

namespace visitorclean.Application.Feature.users.Queries.GetByiduser;

public class GetByIdUserQueryHandler:IRequestHandler<GetByIdUserQuery , Users>
{
    private readonly IUserRepository _repo;

    public GetByIdUserQueryHandler(IUserRepository repo)
    {
        _repo=repo;
        
    }
    public async Task<Users>Handle(GetByIdUserQuery request ,CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}