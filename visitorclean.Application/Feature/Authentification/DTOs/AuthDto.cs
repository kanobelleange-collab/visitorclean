using System;
using visitorclean.Application.Feature.Authentification;



namespace visitorclean.Application.Feature.Authentification.DTOs;

public class AuthResponseDto
{
    public string Token { get; set; }
    public string Username { get; set; }
    public string Role { get; set; }
    public List<string> Permissions { get; set; }
}