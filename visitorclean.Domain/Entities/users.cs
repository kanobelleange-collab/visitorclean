using System;
using visitorclean.Domain.Entities;
using visitorclean.Domain.Entities.role;

namespace visitorclean.Domain.Entities.user;

public class Users
{
    public int  Id{get;set;}
    public string Username{get;set;}
    public string Email{get;set;}
    public string PasswordHash{get;set;}
    public int RoleId{get;set;}
    public string? RoleNom{get;set;}
    public Roles Role{get;set;}

    public Users(){}
    public Users(string username,string email,string passwordhash,int roleId)
    {
        Username=username;
        Email=email;
        PasswordHash=passwordhash;
        RoleId=roleId;
    }
}