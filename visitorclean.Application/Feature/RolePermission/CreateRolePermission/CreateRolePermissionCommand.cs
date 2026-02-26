using MediatR;
using CleanVisitor.Application.Features.RolePermission.Dtos;
using CleanVisitor.Core.Enum.UserRole;
namespace CleanVisitor.Application.Features.RolePermission.Command.CreateRolePermission;
public record CreateRolePermissionCommand : IRequest<RolePermissionDto>
{
    public int RoleId{get;set;}
    public int PermissionId{get;set;}
}