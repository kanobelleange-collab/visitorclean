using MediatR;
using visitorclean.Application.Feature.users.Dto;
using  visitorclean.Application.Feature.users.Interface;
using AutoMapper;
using  visitorclean.Domain.Entities.user;
 using  visitorclean.Application.Feature.users.Queries.GetByEmailUser.GetByEmailUserQuery;
namespace  visitorclean.Application.Feature.users.Queries.QueryHandler.GetByEmailUserHandler;
public class GetByEmailUserHandler:IRequestHandler<GetByEmailUserQuery, Users?>
{
    private readonly IUserRepository _repository;
    private readonly IMapper _mapper;
    public GetByEmailUserHandler(IUserRepository repository, IMapper mapper)
    {
        _repository=repository;
        _mapper=mapper;
    }
    public async Task<Users?>Handle(GetByEmailUserQuery request, CancellationToken cancellationToken)
    {
        var user=_mapper.Map<Users>(request);
        if (user==null) return null;
        return await _repository.GetByEmailAsync(user.Email);
    }
}