using System;
using visitorclean.Domain.Entities;

namespace visitorclean.Domain.Entities;

public class Users
{
    public int  Id{get;set;}
    public string Username{get;set;}
    public string Email{get;set;}
    public string PasswordHash{get;set;}
    public int RoleId{get;set;}
    public string? RoleNom{get;set;}

    public Users(){}
    public Users(string username,string email,string passwordhash,int roleId)
    {
        Username=username;
        Email=email;
        PasswordHash=passwordhash;
        RoleId=roleId;
    }
}