using System;
using visitorclean.Domain.Enums;
using visitorclean.Domain.Entities;



namespace visitorclean.Domain.Entities;

public class Visit{
    public int Id{get;set;}
    public string? Motif {get;set;}
    public DateTime Datevisit{get;set;}
    public Service_A_Visiter? Service_A_Visiter{get ; set;}

    public int idVisitor{get;set;}
    public Visitor? Visitor{get;set;}

    public Visit(){}

    public Visit(string? motif,DateTime datevisit,Service_A_Visiter service_a_visiter){
      
        Motif=motif;
        Datevisit=datevisit;
        Service_A_Visiter=service_a_visiter;
        


    }
    public void Update(string? motif, DateTime datevisit, Service_A_Visiter service_a_visiter)
    {
    Motif = motif;
    Datevisit = datevisit;
    Service_A_Visiter = service_a_visiter;
    }

    



}
