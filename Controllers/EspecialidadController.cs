using System.Linq;
using Microsoft.AspNetCore.Mvc;
using Turnos.Models;

namespace Turnos.Controllers
{
    public class EspecialidadController : Controller
    {
        //Constructor de la clase
        //Lo siguiente es una variable privada de solo lectura del tipo TurnosContext y la misma va a tener un objeto llamado _context
        private readonly TurnosContext _context;
        
        //A continuacion para que el constructor conecte al modelo, debemos pasarle el mismo y el tipo de objeto. 
        //de esta manera enviariamos a travez del controlador los elementos a la vista para que esta lo ejecute.
        public EspecialidadController(TurnosContext context)
        {
            _context = context;
        }

        //El siguiente metodo muestra los datos en la pantalla del usuario
        //IActionResult retorna la informacion contenida dentro del metodo a la vista del usuario, en este caso index

        public IActionResult Index()
        {

            //Lo siguiente indica que al resultado de este metodo lo retorna a la vista index, lo que devolvemos es un objeto del tipo
            //_context, el mismo va a acceder a la tabla especialidad y a travez de ToList seleccionamos toda la tabla para tomar sus valores
            //similar al select*
            return View(_context.Especialidad.ToList());
        }

        //Agregamos el metodo editar

        public IActionResult Edit(int? Id)
        {
            if(Id == null)
            {
                return NotFound();
            }
            var especialidad = _context.Especialidad.Find(Id);

            if(especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        //El siguiente metodo editar cumple la funcion de POST, es decir va a recibir el parametro Id del turno para darnos la posibilidad
        //de editar.
        [HttpPost]
        public IActionResult Edit(int Id, [Bind("idEspecialidad,Descripcion")]Especialidad especialidad)
        {
            if(Id != especialidad.idEspecialidad)
            {
                return NotFound();
            }
        //Lo siguiente es para que, si el enlace a traves de bind a la base de datos fue correcto y todos sus elementos concuerdan con la base
        //quiere decir que estamos en condiciones de grabar nuestros datos.
            if(ModelState.IsValid)
            {
                //A continuacion pasamos los datos a nuestra vista index una vez guardada la informacion en nuestra BD
                _context.Update(especialidad);
                _context.SaveChanges();
                return RedirectToAction(nameof(Index));
            }
            return View(especialidad);
        }

        public IActionResult Delete(int? id)
        {
            if (id == 0)
            {
                return NotFound();
            }
            //De la siguiente manera ingresamos a nuestro campo especialidad y a traves del metodo 
            //FirstOrDefault va a encontrar la primer coincidencia que se asimile al id que ingresa como parametro Y en el caso que no 
            //retorne nada devuelve default.

            var especialidad = _context.Especialidad.FirstOrDefault(e => e.idEspecialidad == id);
            //En el caso que no exista la especialidad devuelve NotFound a traves de la sig validacion
            if(especialidad == null)
            {
                return NotFound();
            }
            return View(especialidad);
        }

        [HttpPost]
        public IActionResult Delete(int id)
        {
            var especialidad = _context.Especialidad.Find(id);
            _context.Especialidad.Remove(especialidad);
            _context.SaveChanges();

            return RedirectToAction(nameof(Index));
        }
    }
}
