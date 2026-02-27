using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.users.Dto;
using AutoMapper;
using MediatR;
using visitorclean.Application.Feature.users.Interface;

namespace visitorclean.Application.Feature.users.Commands.updateuser;

public record UpdateUserCommand : IRequest<UserDto>
{
    public int Id{get;set;}
     public required string Username {get;set;}
     public required string Email{get;set;}
    public required string PasswordHash{get; set;}
    public  required int RoleId{get;set;}
    public required int UserId{get;set;}
}