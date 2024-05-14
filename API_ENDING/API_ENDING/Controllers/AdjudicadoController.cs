using API_ENDING.Models;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ENDING.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class AdjudicadoController : ControllerBase
    {

        public readonly ProyectoWebContext webcontext;

        public AdjudicadoController(ProyectoWebContext _context)
        {
            webcontext = _context;
        }

        //Muestra una lista de los adjudicados
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Adjudicado> adjudicados = new List<Adjudicado>();

            try
            {
                adjudicados = webcontext.Adjudicado.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = adjudicados });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = adjudicados });
            }
        }

        //BUSCA UN ADJUDICADO POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idAdjudicado:int}")]
        public IActionResult Obtener(int idAdjudicado)
        {
            //busca dentro de la tabla inmobiliaria por medio del web context usando el idInmobiliaria
            Adjudicado adjudicados = webcontext.Adjudicado.Find(idAdjudicado);

            if (adjudicados == null)
            {
                return BadRequest("Inmobiliaria no encontrada");
            }

            try
            {
                //llama al objeto inmobiliarias y usando al webcontext incluye los remates de la inmobiliaria que se buscó por medio del id de la inmobiliaria
                //y en caso de que encuntre datos, manda el primero, en caso contrario, va a mandar un nulo
                adjudicados = webcontext.Adjudicado.Where(i => i.IdAdjudicado == idAdjudicado).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = adjudicados });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new {mensaje = ex.Message, Response = adjudicados });
            }
        }

        //GUARDA UN NUEVO ADJUDICADO
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Adjudicado objeto)
        {
            try
            {
                webcontext.Adjudicado.Add(objeto);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        //EDITA DATOS DE UN ADJUDICADO
        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Adjudicado objeto)
        {
            Adjudicado adjudicados = webcontext.Adjudicado.Find(objeto.IdAdjudicado);

            if (adjudicados == null)
            {
                return BadRequest("Inmobiliaria no encontrada");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                adjudicados.Nombres = objeto.Nombres is null ? adjudicados.Nombres : objeto.Nombres;
                adjudicados.Apellidos = objeto.Apellidos is null ? adjudicados.Apellidos : objeto.Apellidos;
                adjudicados.Rfc = objeto.Rfc is null ? adjudicados.Rfc : objeto.Rfc;
                adjudicados.Curp = objeto.Curp is null ? adjudicados.Curp : objeto.Curp;
                adjudicados.Telefono = objeto.Telefono is null ? adjudicados.Telefono : objeto.Telefono;
                adjudicados.Num = objeto.Num is null ? adjudicados.Num : objeto.Num;
                adjudicados.Colonia = objeto.Colonia is null ? adjudicados.Colonia : objeto.Colonia;
                adjudicados.Municipio = objeto.Municipio is null ? adjudicados.Municipio : objeto.Municipio;
                adjudicados.Estado = objeto.Estado is null ? adjudicados.Estado : objeto.Estado;
                adjudicados.Cp = objeto.Cp is null ? adjudicados.Cp : objeto.Cp;
                adjudicados.SemafonoEscrituracion = objeto.SemafonoEscrituracion is null ? adjudicados.SemafonoEscrituracion : objeto.SemafonoEscrituracion;
                adjudicados.Consideraciones = objeto.Consideraciones is null ? adjudicados.Consideraciones : objeto.Consideraciones;
                adjudicados.EstadoAdjudicacion = objeto.EstadoAdjudicacion is null ? adjudicados.EstadoAdjudicacion : objeto.EstadoAdjudicacion;

                webcontext.Adjudicado.Update(adjudicados);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        //Elimina datos de un adjudicado por medio de un ID
        [HttpDelete]
        [Route("Eliminar/{idAdjudicado:int}")]
        public IActionResult Eliminar(int idAdjudicado)
        {
            Adjudicado adjudicados = webcontext.Adjudicado.Find(idAdjudicado);

            if (adjudicados == null)
            {
                return BadRequest("Adjudicado no encontrada");
            }

            try
            {
                webcontext.Adjudicado.Remove(adjudicados);
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
