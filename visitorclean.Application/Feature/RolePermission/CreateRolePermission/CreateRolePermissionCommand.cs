using MediatR;
using AutoMapper;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.RolePermission.Dtos;
using visitorclean.Application.Feature.RolePermission.Interfaces;
namespace visitorclean.Application.Feature.RolePermission.Command.CreateRolePermission;
public record CreateRolePermissionCommand : IRequest<RolePermissionDto>
{
    public int RoleId{get;set;}
    public int PermissionId{get;set;}
}