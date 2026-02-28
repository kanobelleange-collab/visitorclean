using System;
using MediatR;
using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.users.Queries.GetByiduser;
using visitorclean.Application.Feature.users.Interface;
using visitorclean.Application.Feature.users.Dto;

namespace visitorclean.Application.Feature.users.Queries.GetByiduser;

public class GetByIdUserQueryHandler:IRequestHandler<GetByIdUserQuery , UserDto?>
{
    private readonly IUserRepository _repo;

    public GetByIdUserQueryHandler(IUserRepository repo)
    {
        _repo=repo;
        
    }
    public async Task<UserDto?>Handle(GetByIdUserQuery request ,CancellationToken cancellationToken)
    {
        return await _repo.GetByIdAsync(request.Id);
    }
}