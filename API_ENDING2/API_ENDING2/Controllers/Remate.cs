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
            try
            {
                // Proyección a DTO
                var remateDto = webcontext.Remates
                    .Select(i => new RemateDTO
                    {
                        IdRemate = i.IdRemate,
                        IdInmobiliaria = i.IdInmobiliaria,
                        Fiscalia = i.Fiscalia,
                        Estado = i.Estado,
                        Fecha = i.Fecha,
                        Descripcion = i.Descripcion,
                    })
                    .ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = remateDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        //BUSCA UN REMATE POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idRemate:int}")]
        public IActionResult Obtener(int idRemate)
        {
            try
            {
                // Buscar el remate por ID y proyectar al DTO
                var remateDto = webcontext.Remates
                    .Where(r => r.IdRemate == idRemate)
                    .Select(r => new RemateDTO
                    {
                        IdRemate = r.IdRemate,
                        IdInmobiliaria = r.IdInmobiliaria,
                        Fiscalia = r.Fiscalia,
                        Estado = r.Estado,
                        Fecha = r.Fecha,
                        Descripcion = r.Descripcion
                    })
                    .FirstOrDefault();

                if (remateDto == null)
                {
                    return BadRequest("Remate no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = remateDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
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
                    IdInmobiliaria = newRemate.IdInmobiliaria,
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
                // Captura la inner exception para obtener más detalles del error
                var innerExceptionMessage = ex.InnerException?.Message;
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message, detalle = innerExceptionMessage });
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
                remates.IdInmobiliaria = newRemate.IdInmobiliaria == 0 ? remates.IdInmobiliaria : newRemate.IdInmobiliaria;
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
