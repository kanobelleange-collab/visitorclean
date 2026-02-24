using System.Data;
using Microsoft.Extensions.Configuration;
using Microsoft.Data.SqlClient;

namespace visitorclean.Infrastructure.Dbcontext;

public class DbContext{
    private readonly IConfiguration _configuration;
    private readonly string  _connectionString;

    public DbContext(IConfiguration configuration){ 
    _configuration=configuration;
   _connectionString = _configuration.GetConnectionString("DefaultConnection") ?? throw new InvalidOperationException("Connection string manquante !");

    }

   
 
    public IDbConnection CreateConnection(){

        return new SqlConnection(_connectionString);
    }
    
    
    }