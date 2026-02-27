using System;
using visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Feature.visit.Commands.updatevisit;


using visitorclean.Application.Feature.visitor.Commands.createvisitor;
using visitorclean.Application.Feature.visitor.Commands.updatevisitor;
using visitorclean.Application.Feature.visitor.Commands.deletevisitor;

using visitorclean.Application.Feature.role.Commands.createRole;


using visitorclean.Application.Feature.users.Commands.createuser;
using visitorclean.Application.Feature.users.Commands.updateuser;



namespace visitorclean.Application.Common;

public static class AppPermission
{
    //permisssion visit
    public const string CreateVisit = "CreateVisit";
    public const string UpdateVisit = "UpdateVisit";
    public const string DeleteVisit = "DeleteVisit";
    public const string ViewVisit   = "ViewVisit";

//PERMISSION visitor
    public const string CreateVisitor = "CreateVisitor";
    public const string UpdateVisitor = "UpdateVisitor";
    public const string DeleteVisitor = "DeleteVisitor";

    public const string ViewDashboard = "ViewDashboard";

//permission Roles

    public const string CreateRole="CreateRoles";
    public const string UpdateRole="UpdateRoles";
    public const string ViewRole="ViewRoles";

// permission Users

    public const string CreateUser="CreateUsers";
    public const string UpdateUser="UpdateUsers";
    public const string DeleteUser="DeleteUsers";
}