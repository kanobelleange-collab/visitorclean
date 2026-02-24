using visitorclean.Domain.Entities;
using visitorclean.Application.DTOs;
using AutoMapper;
using MediatR;
using visitorclean.Application.Interface;


namespace visitorclean.Application.Feature.visit.Commands.updatevisit;

public record UpdateUserCommand : IRequest<UserDto>
{
     public string Username {get;set;}
     public  string Email{get;set;}
    public string PasswordHash{get; set;}
    public int RoleId{get;set;}
}