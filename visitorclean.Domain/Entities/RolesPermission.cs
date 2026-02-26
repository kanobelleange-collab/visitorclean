using System;
using visitorclean.Domain.Entities.role;
using visitorclean.Domain.Entities.Permission;
namespace visitorclean.Domain.Entities;
public class RolesPermissions
{
    public int RoleId{get;set;}
    public int PermissionId{get;set;}
    public Roles ?Role{get;set;}
    public Permissions ?Permission{get;set;}
    
}