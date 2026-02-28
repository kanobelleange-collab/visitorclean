using MediatR;
using visitorclean.Domain.Entities.user;
namespace visitorclean.Application.Feature.users.Queries.GetByEmailUser.GetByEmailUserQuery;
public record GetByEmailUserQuery : IRequest<Users>
{
    public string Email{get;set;}=string.Empty;
    public GetByEmailUserQuery(string email)
    {
        Email=email ;
    }
}