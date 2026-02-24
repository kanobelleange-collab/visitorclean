using System;
using visitorclean.Domain.Entities;
using System.Text;

namespace visitorclean.Domain.Entities;

public class Visitor
{
    public int id{get;set;}
    public string Nom{get;set;}
    public string Email{get;set;}
    public byte[] Passwordhash{get;set;}
    public DateTime CreatedAT {get;set;}=DateTime.Now;
    public ICollection<Visit>Visits{get;set;}=new List<Visit>();

    protected Visitor() { } // 🔥 OBLIGATOIRE POUR DAPPER
    public Visitor(string nom,string email,string password,DateTime createdAT)
    {
        Nom=nom;
        Email=email;
       Passwordhash = ConvertPasswordToBytes(password);
        CreatedAT=createdAT;


    }
    public void Update(string nom, string email, string password)
    {
            Nom = nom;
            Email = email;
            if (!string.IsNullOrEmpty(password))
            {
            Passwordhash = ConvertPasswordToBytes(password);
            }
        
    }
     private byte[] ConvertPasswordToBytes(string password)
        {
            return Encoding.UTF8.GetBytes(password);
        }
    
    
   

}
