using System;
using visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Feature.visit.Commands.updatevisit;
using visitorclean.Application.Feature.visit.Commands.deletevisit;

using visitorclean.Application.Feature.visitor.Commands.createvisitor;
using visitorclean.Application.Feature.visitor.Commands.updatevisitor;
using visitorclean.Application.Feature.visitor.Commands.deletevisitor;

using visitorclean.Application.Feature.role.Commands.createRole;
using visitorclean.Application.Feature.role.Commands.updateRole;

using visitorclean.Application.Feature.users.Commands.createuser;
using visitorclean.Application.Feature.users.Commands.updateuser;



namespace visitorclean.Application.Common;

public static class Permissions
{
    //permisssion visit
    public const string createvisit = "Create_Visit";
    public const string updatevisit = "Update_Visit";
    public const string deletevisit = "Delete_Visit";
    public const string viewvisit   = "View_Visit";

//PERMISSION visitor
    public const string createvisitor = "Create_Visitor";
    public const string updatevisitor = "Update_Visitor";
    public const string deletevisitor = "Delete_Visitor";

    public const string viewDashboard = "View_Dashboard";

//permission Roles

    public const string createRole="Create_Roles";
    public const string updateRole="Update_Roles";
    public const string viewRole="View_Roles";

// permission Users

    public const string createuser="Create_Users";
    public const string updateuser="Update_Users";
    public const string deleteuser="Delete_Users";
}