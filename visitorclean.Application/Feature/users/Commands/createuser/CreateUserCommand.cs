using visitorclean.Domain.Entities;
using System;
using System.Threading.Tasks;
using MediatR;
using visitorclean.Domain.Enum;
using visitorclean.Application.Feature.users.Dto;

namespace visitorclean.Application.Feature.users.Commands.createuser;

public record CreateUserCommand: IRequest<UserDto>
{
   
    public required string Username {get;set;}
     public  required string Email{get;set;}
    public required  string PasswordHash{get; set;}
    public  required  int RoleId{get;set;}



}
