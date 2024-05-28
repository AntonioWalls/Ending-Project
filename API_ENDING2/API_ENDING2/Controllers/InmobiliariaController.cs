using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;
using API_ENDING2.Models;
using Microsoft.AspNetCore.Cors;
using API_ENDING2.DTO;

namespace API_ENDING.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class InmobiliariaController : ControllerBase
    {
        public readonly ProyectoWebContext webcontext;

        public InmobiliariaController(ProyectoWebContext _context)
        {
            webcontext = _context;
        }


        //Muestra una lista de las inmobiliarias creadas en la base de datos
        //Junto a sus remates
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Inmobiliaria> inmobiliarias = new List<Inmobiliaria>();

            try
            {
                inmobiliarias = webcontext.Inmobiliaria.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = inmobiliarias });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = inmobiliarias });
            }
        }


        //BUSCA UNA INMOBILIARIA POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idInmobiliaria:int}")]
        public IActionResult Obtener(int idInmobiliaria)
        {
            //busca dentro de la tabla inmobiliaria por medio del web context usando el idInmobiliaria
            Inmobiliaria inmobiliarias = webcontext.Inmobiliaria.Find(idInmobiliaria);

            if (inmobiliarias == null)
            {
                return BadRequest("Inmobiliaria no encontrada");
            }

            try
            {
                //llama al objeto inmobiliarias y usando al webcontext incluye los remates de la inmobiliaria que se buscó por medio del id de la inmobiliaria
                //y en caso de que encuntre datos, manda el primero, en caso contrario, va a mandar un nulo
                inmobiliarias = webcontext.Inmobiliaria.FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = inmobiliarias });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new {mensaje = ex.Message, Response = inmobiliarias });
            }
        }

        //GUARDA UNA NUEVA INMOBILIARIA
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] InmobiliariaDTO newInmobiliaria)
        {
            try
            {
                var objeto = new Inmobiliaria()
                {
                    RazonSocial = newInmobiliaria.RazonSocial,
                    Rfc = newInmobiliaria.Rfc,
                    Telefono = newInmobiliaria.Telefono,
                };
                webcontext.Inmobiliaria.Add(objeto);
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
        public IActionResult Editar([FromBody] InmobiliariaDTO newInmobiliaria)
        {
            Inmobiliaria inmobiliarias = webcontext.Inmobiliaria.Find(newInmobiliaria.IdInmobiliaria);
            
            if (inmobiliarias == null)
            {
                return BadRequest("Inmobiliaria no encontrada");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                inmobiliarias.RazonSocial = newInmobiliaria.RazonSocial is null? inmobiliarias.RazonSocial : newInmobiliaria.RazonSocial;
                inmobiliarias.Rfc = newInmobiliaria.Rfc is null? inmobiliarias.Rfc : newInmobiliaria.Rfc;
                inmobiliarias.Telefono = newInmobiliaria.Telefono is null? inmobiliarias.Telefono : newInmobiliaria.Telefono;
            
                webcontext.Inmobiliaria.Update(inmobiliarias);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch(Exception ex) 
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });  
            }
        }


        //Elimina datos de una inmobiliaria por medio de un ID
        [HttpDelete]
        [Route("Eliminar/{idInmobiliaria:int}")]
        public IActionResult Eliminar(int idInmobiliaria)
        {
            Inmobiliaria inmobiliarias = webcontext.Inmobiliaria.Find(idInmobiliaria);

            if (inmobiliarias == null)
            {
                return BadRequest("Inmobiliaria no encontrada");
            }

            try
            {
                webcontext.Inmobiliaria.Remove(inmobiliarias);
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
