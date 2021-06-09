using System.ComponentModel.DataAnnotations;

namespace Turnos.Models
{
    public class Especialidad
    {
        //A continuacion definimos las propiedades
        [Key] //Con  esto le indicamos al entityFramework que el siguiente metodo es un primary key
        public int idEspecialidad //Esta sera la primary key de nuestra tabla
        {
            get;
            set;
        }

        //Lo siguiente es la descripcion de la especialidad...
        public string Descripcion
        {
            get;
            set; 
        }
    }
}