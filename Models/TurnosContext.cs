using Microsoft.EntityFrameworkCore;

namespace Turnos.Models
{
    public class TurnosContext : DbContext
    {
        //A continuacion tenemos el constructor, la misma tiene parametros por default para que los inicialice en el mismo
        //basandose en las propiedades de nuestra clase TurnosContext.
        // Con base(opciones) lo que hacemos es  heredar las opciones de base a TurnosContext

        public TurnosContext(DbContextOptions<TurnosContext> opciones):base(opciones) 
        {

        }

        //A continuacion definimos un objeto entidad que es del tipo DbSet, este es una tabla, de la manera que esta definido
        //definimos que es del tipo especialidad. Este va a ser el nombre final de la tabla en nuestro motor SQL Server.
        public DbSet<Especialidad> Especialidad {get; set;}
    }
}