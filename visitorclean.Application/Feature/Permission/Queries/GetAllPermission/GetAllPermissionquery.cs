using MediatR;
using visitorclean.Domain.Entities;

public record GetAllPermissionsQuery() 
    : IRequest<List<Permissions>>;