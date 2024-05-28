using API_ENDING2.DTO;
using API_ENDING2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ENDING2.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class RemateController : ControllerBase
    {
        public readonly ProyectoWebContext webcontext;

        public RemateController(ProyectoWebContext _context)
        {
            webcontext = _context;
        }

        //Muestra una lista de los remates creados en la base de datos
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Remate> remates = new List<Remate>();

            try
            {
                remates = webcontext.Remates.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = remates });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = remates });
            }
        }

        //BUSCA UN REMATE POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idRemate:int}")]
        public IActionResult Obtener(int idRemate)
        {
            //busca dentro de la tabla remates por medio del web context usando el idRemate
            Remate remates = webcontext.Remates.Find(idRemate);

            if (remates == null)
            {
                return BadRequest("Remate no encontrado");
            }

            try
            {
                //llama al objeto inmobiliarias y usando al webcontext incluye los remates de la inmobiliaria que se buscó por medio del id de la inmobiliaria
                //y en caso de que encuntre datos, manda el primero, en caso contrario, va a mandar un nulo
                remates = webcontext.Remates.FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = remates });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = remates });
            }
        }


        //GUARDA UN NUEVO REMATE
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] RemateDTO newRemate)
        {
            try
            {
                var objeto = new Remate()
                {
                    Fiscalia = newRemate.Fiscalia,
                    Estado = newRemate.Estado,
                    Fecha = newRemate.Fecha,
                    Descripcion = newRemate.Descripcion
                };
                webcontext.Remates.Add(objeto);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        //EDITA DATOS DE LA INMOBILIARIA
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] RemateDTO newRemate)
        {
            Remate remates = webcontext.Remates.Find(newRemate.IdRemate);

            if (remates == null)
            {
                return BadRequest("Remate no encontrado");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                remates.Fiscalia = newRemate.Fiscalia is null ? remates.Fiscalia : newRemate.Fiscalia;
                remates.Estado = newRemate.Estado;
                remates.Fecha = newRemate.Fecha is null ? remates.Fecha : newRemate.Fecha;
                remates.Descripcion = newRemate.Descripcion is null ? remates.Descripcion : newRemate.Descripcion;


                webcontext.Remates.Update(remates);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        //Elimina datos de una inmobiliaria por medio de un ID
        [HttpDelete]
        [Route("Eliminar/{idRemate:int}")]
        public IActionResult Eliminar(int idRemate)
        {
            Remate remates = webcontext.Remates.Find(idRemate);

            if (remates == null)
            {
                return BadRequest("Remate no encontrado");
            }

            try
            {
                webcontext.Remates.Remove(remates);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }

        }

    }
}
