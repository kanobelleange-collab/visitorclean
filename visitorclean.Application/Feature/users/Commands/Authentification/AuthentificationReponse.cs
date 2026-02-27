using System;
using visitorclean.Domain.Entities.user;
public record AuthenticationResponse(Users user, string Token);