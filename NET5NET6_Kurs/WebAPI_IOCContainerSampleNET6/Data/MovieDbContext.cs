using Microsoft.EntityFrameworkCore;
using WebAPI_IOCContainerSampleNET6.Models;

namespace WebAPI_IOCContainerSampleNET6.Data
{
    //DbContext ist die Klasse, die eine Verbindung zur DB Aufbaut und diese auch verwaltet (ConnectionString, Timeout) 
    //DbContext umschließt die Ansicht auf die zu verbindene Datenbank (Welche Tabelle kann ich ansteuern) -> Wird mit DBSet<T> realisiert. 



    //EF Core beinhaltet folgende Design-Patterns-> Repository-Design Pattern + UnitOfWork - Design Pattern!


    //Was ist Repository-Design Pattern -> Ein Repository (Klasse), die sich um das CRUD (Creat, Read, Update, Delete) gegenüber eine DB-Tabelle kümmert.
    //Was ist UnitOfWork -> Wenn ein Datensatz hinzugefügt wird, wird dieser mit der Add-Methode zum hinzufügen markiert. Erst beim DBContext.SaveChanges() wird SQL erzeugt 

    public class MovieDbContext : DbContext
    {
        public MovieDbContext(DbContextOptions<MovieDbContext> options) 
            : base(options) 
        { 

        }

        public DbSet<Movie> Movies { get; set; } //Tabellennamen werden Via Property-Name definiert (Im CodeFirst Szenario) 
    }
}
