using System.Net;
using MediatR;
using visitorclean.Domain.Entities;
using visitorclean.Application.Feature.visitor.Commands;



namespace visitorclean.Application.Feature.visitor.Queries.GetByidvisitor;

public class GetByIdVisitorquery : IRequest<Visitor>
{
    public int Id{get;set;}
    public GetByIdVisitorquery(int id)
    {
        Id=id;
    }
}