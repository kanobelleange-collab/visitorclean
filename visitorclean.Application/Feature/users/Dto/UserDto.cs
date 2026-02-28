using visitorclean.Domain.Entities;
using System;


namespace visitorclean.Application.Feature.users.Dto;

public class UserDto
{
   public  required string Username {get;set;}
     public   required string Email{get;set;}
    public required  string PasswordHash{get; set;}
    public string? RoleNom{get;set;}  
    public int Id{get;set;}
    public int RoleId{get;set;}
}
