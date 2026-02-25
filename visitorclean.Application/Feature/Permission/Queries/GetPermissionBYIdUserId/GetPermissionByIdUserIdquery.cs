using MediatR;
using visitorclean.Domain.Entities;
public record GetPermissionsByUserIdQuery(int UserId)
    : IRequest<List<string>>;