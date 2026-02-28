using System;
using visitorclean.Domain.Entities.user;
using visitorclean.Application.Feature.users.Dto;

public class AuthenticationResponse
{
    public UserDto User { get; set; }
    public string Token { get; set; }

    public AuthenticationResponse(UserDto user, string token)
    {
        User = user;
        Token = token;
    }
}