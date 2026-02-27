using System;



namespace visitorclean.Domain.Entities;

public class Permissions
{
    public int Id { get; private set; }

    public string Resource { get; private set; }
    public string Action { get; private set; }

    public string Nom { get; private set; }

    public string? Description { get; private set; }

    public DateTime CreatedAt { get; private set; }

    public Permissions(string resource, string action, string? description = null)
    {
        Resource = resource;
        Action = action;
        Description = description;
    }
}