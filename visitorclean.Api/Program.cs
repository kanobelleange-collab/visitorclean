using visitorclean.Application.Interface;
using visitorclean.Infrastructure.Repository;
using visitorclean.Infrastructure.Dbcontext;
using MediatR;
using AutoMapper;
using visitorclean.Application.Service;
using visitorclean.Application.Feature.visitor.Commands.createvisitor;
using visitorclean.Application.Feature.visitor.Commands.updatevisitor;
using visitorclean.Application.Feature.visitor.Commands.deletevisitor;
using visitorclean.Application.Feature.visit.Commands.createvisit;
using visitorclean.Application.Feature.visit.Commands.updatevisit;
using visitorclean.Application.Feature.visit.Mapping;
using visitorclean.Application.Feature.role.Commands.createRole;
using visitorclean.Application.Feature.users.Commands.Updateuser;
using viistorclean.Application.Feature.users.Commands.createuser;


using System.Text.Json.Serialization;


var builder = WebApplication.CreateBuilder(args);

// Controllers + Swagger
builder.Services.AddControllers();
builder.Services.AddEndpointsApiExplorer();
builder.Services.AddSwaggerGen();

// AutoMapper
builder.Services.AddAutoMapper(AppDomain.CurrentDomain.GetAssemblies());
builder.Services.AddAutoMapper(typeof(VisitMapping));
builder.Services.AddControllers()
    .AddJsonOptions(options =>
    {
        options.JsonSerializerOptions.Converters.Add(
            new JsonStringEnumConverter());
    });




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
        typeof(CreateVisitCommandHandler).Assembly,
        typeof(UpdateVisitCommandHandler).Assembly
        
    );
});


// DbContext, repository et service
builder.Services.AddScoped<DbContext>();
builder.Services.AddScoped<IVisitorRepository, VisitorRepository>();
builder.Services.AddScoped<ISecurityService, SecurityService>();
builder.Services.AddScoped<IVisitRepository, VisitRepository>();
builder.Services.AddScoped<IVisitorReadRepository, VisitorWithVisitRepository>();
builder.Services.AddScoped<IDashboardRepository, DashboardRepository>();


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
app.UseAuthorization();
app.MapControllers();

app.Run();
