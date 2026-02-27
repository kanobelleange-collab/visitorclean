using MediatR;
using visitorclean.Domain.Entities;
namespace visitorclean.Application.Permission.Queries.GetAllPermission.GetAllPermissionsQuery;
public record GetAllPermissionsQuery() 
    : IRequest<List<Permissions>>;