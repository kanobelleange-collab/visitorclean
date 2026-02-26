using System;
using visitorclean.Domain.Entities;
public record AuthenticationResponse(User user, string Token);