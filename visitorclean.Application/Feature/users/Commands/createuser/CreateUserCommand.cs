using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using MediatR;
using visitorclean.Domain.Enums;
using visitorclean.Application.DTOs;

namespace visitorclean.Application.Feature.users.Commands.createuser;

public record CreateUserCommand: IRequest<UserDto>
{
   
    public string Username {get;set;}
     public  string Email{get;set;}
    public string PasswordHash{get; set;}
    public int RoleId{get;set;}



}
