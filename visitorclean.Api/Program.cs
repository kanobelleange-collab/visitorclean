using visitorclean.Application.Feature.visit.Interface;
using visitorclean.Application.Feature.Permission.Interface;
using visitorclean.Application.Feature.visitor.Interface;
using visitorclean.Application.Feature.Dashboard.Interface;
using visitorclean.Application.Feature.role.Interface;
using visitorclean.Application.Feature.users.Interface;
using Microsoft.AspNetCore.Authorization;
using visitorclean.Infrastructure.Repository;
using visitorclean.Application.Feature.Authentification.Commands.Login;
using visitorclean.Application.Feature.Authentification.Interface;
using visitorclean.Application.Feature.Authentification.Commands.Register;
using visitorclean.Application.Feature.Authentification.DTOs;
using visitorclean.Infrastructure.Dbcontext;
using visitorclean.Application.Feature.RolePermission.Interfaces;
using visitorclean.Infrastructure.Repositories;
using visitorclean.Infrastructure.Repositories.RolePermissionRepository;
using visitorclean.Application.Feature.visitor.Commands.createvisitor;
using visitorclean.Application.Feature.visitor.Commands.updatevisitor;
using visitorclean.Application.Feature.visitor.Commands.deletevisitor;
using visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Feauture.visit.Commands.createvisit;
using visitorclean.Application.Feature.visit.Commands.updatevisit;
using visitorclean.Application.Feature.visit.MappingVisit;
using visitorclean.Infrastructure.AuthService;
using Microsoft.Extensions.Configuration;
using visitorclean.Application.Feature.users.Commands.updateuser;
using visitorclean.Application.Feature.users.Interface.IJwtTokenGenerator;
using visitorclean.Application.Service.Security;
using Microsoft.AspNetCore.Authentication.JwtBearer;
using Microsoft.IdentityModel.Tokens;
using System.Text;
using visitorclean.Application.Service.Interface;


using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();
// 1. Récupération de la clé depuis builder.Configuration
var jwtKey = builder.Configuration["Jwt:Key"];

if (string.IsNullOrEmpty(jwtKey))
{
    throw new Exception("Jwt:Key est null ou vide dans appsettings.json");
}

builder.Services.AddAuthentication(options => {
    options.DefaultAuthenticateScheme = JwtBearerDefaults.AuthenticationScheme;
    options.DefaultChallengeScheme = JwtBearerDefaults.AuthenticationScheme;
})
.AddJwtBearer(options =>
{
    options.TokenValidationParameters = new TokenValidationParameters
    {
        ValidateIssuer = true,
        ValidateAudience = true,
        ValidateLifetime = true,
        ValidateIssuerSigningKey = true,

        // On utilise builder.Configuration pour être raccord avec le générateur
        ValidIssuer = builder.Configuration["Jwt:Issuer"],
        ValidAudience = builder.Configuration["Jwt:Audience"],
        IssuerSigningKey = new SymmetricSecurityKey(Encoding.UTF8.GetBytes(jwtKey))
    };
});

builder.Services.AddAuthorization();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(MapperVisit));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });


    builder.Services.AddSwaggerGen(options =>
{
    options.AddSecurityDefinition("Bearer", new Microsoft.OpenApi.Models.OpenApiSecurityScheme
    {
        Name = "Authorization",
        Type = Microsoft.OpenApi.Models.SecuritySchemeType.Http,
        Scheme = "bearer",
        BearerFormat = "JWT",
        In = Microsoft.OpenApi.Models.ParameterLocation.Header,
        Description = "Entrer 'Bearer' [espace] et ton token"
    });

    options.AddSecurityRequirement(new Microsoft.OpenApi.Models.OpenApiSecurityRequirement
    {
        {
            new Microsoft.OpenApi.Models.OpenApiSecurityScheme
            {
                Reference = new Microsoft.OpenApi.Models.OpenApiReference
                {
                    Type = Microsoft.OpenApi.Models.ReferenceType.SecurityScheme,
                    Id = "Bearer"
                }
            },
            new string[] {}
        }
    });
});
// Assure-toi d'injecter IConfiguration dans le constructeur de ton service


// MediatR
builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateVisitorCommandHandler).Assembly,
        typeof(UpdateVisitorCommandHandler).Assembly,
        typeof(DeleteVisitorCommandHandler).Assembly
    );
});

builder.Services.AddMediatR(cfg =>
{
    cfg.RegisterServicesFromAssemblies(
        typeof(CreateVisitHandler).Assembly,
        typeof(UpdateVisitHandler).Assembly
        
    );
});
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        // Empêche les boucles infinies lors de la lecture des entités liées
        options.JsonSerializerOptions.ReferenceHandler = System.Text.Json.Serialization.ReferenceHandler.IgnoreCycles;
    });

// DbContext, repository et service
builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<IRolePermissionRepository, RolePermissionRepository>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();
builder.Services.AddScoped<IVisitorReadRepository, VisitorWithVisitRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();
builder.Services.AddScoped<IPermissionRepository, PermissionRepository>();
builder.Services.AddScoped<IUserRepository, UserRepository>();
builder.Services.AddScoped<IRoleRepository, RoleRepository>();
builder.Services.AddScoped<ITokenService, TokenService>();
builder.Services.AddScoped<IPermissionService, PermissionService>();
builder.Services.AddScoped<IJwtTokenGenerator, JwtTokenGenerator>();

// CORS
builder.Services.AddCors(o => o.AddDefaultPolicy(p => p.AllowAnyOrigin().AllowAnyHeader().AllowAnyMethod()));

var app = builder.Build();

// Pipeline
if (app.Environment.IsDevelopment())
{
    app.UseSwagger();
    app.UseSwaggerUI();
}

app.UseCors();
app.UseHttpsRedirection();
app.UseAuthentication();
app.UseAuthorization();
app.MapControllers();

app.Run();
