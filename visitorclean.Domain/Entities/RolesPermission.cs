using System;
using visitorclean.Domain.Entities.role;
using visitorclean.Domain.Entities;
namespace visitorclean.Domain.Entities.rolles_permissions;
public class RolesPermission
{
    public int RoleId{get;set;}
    public int PermissionId{get;set;}
    public Roles ?Role{get;set;}
    public Permissions ?Permission{get;set;}
    
}