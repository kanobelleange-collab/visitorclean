using visitorclean.Domain.Entities;
using System;


namespace visitorclean.Application.DTOs;

public class UserDto
{
   public string Username {get;set;}
     public  string Email{get;set;}
    public string PasswordHash{get; set;}
    public string? RoleNom{get;set;}  
}
