using visitorclean.Domain.Entities;
using MediatR;
using System;

namespace visitorclean.Application.Feature.visitor.Queries;

public class GetAllvisitorquery:IRequest<IEnumerable<Visitor>>{
    public int id{get;set;}

}
