using Microsoft.EntityFrameworkCore;
using HospiEnCasa.App.Dominio;

namespace HospiEnCasa.App.Persistencia
{
    public class AppContext : DbContext
    {
        public DbSet<Persona> Personas {get;set;}
        public DbSet<Paciente> Pacientes {get;set;}
        public DbSet<Medico> Medicos {get;set;} 

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder) 
        {       
            if(!optionsBuilder.IsConfigured) 
            {   
                // Ejecutar en windows
                optionsBuilder.UseSqlServer("Data Source = (localdb)\\MSSQLLocalDB; Initial Catalog = HospiEncasatData");

                // Ejecutar en mac
                // var user = "";
                // var pass = "";
                // optionsBuilder.UseSqlServer("Server=localhost,1433\\MSSQLLocalDB;Initial Catalog=HospiEncasatData;User=" + user + ";Password=" + pass);
            }
        } 

    }

}