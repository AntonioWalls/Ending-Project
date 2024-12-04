using API_ENDING2.DTO;
using API_ENDING2.Models;
using API_ENDING2.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ENDING2.Controllers
{
    [EnableCors ("ReglasCors")]
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
            try
            {
                var adjudicadosDto = webcontext.Adjudicados
                    .Select(i=> new AdjudicadoDTO
                    {
                        IdAdjudicado = i.IdAdjudicado,
                        IdRemate = i.IdRemate,
                        Nombres = i.Nombres,
                        Apellidos = i.Apellidos,
                        Rfc = i.Rfc,
                        Curp = i.Curp,
                        Telefono = i.Telefono,
                        Calle = i.Calle,
                        Num = i.Num,
                        Colonia = i.Colonia,
                        Municipio = i.Municipio,
                        Estado = i.Estado,
                        Cp = i.Cp,
                        SemafonoEscrituracion = i.SemafonoEscrituracion,
                        Consideraciones = i.Consideraciones,
                        EstadoAdjudicacion = i.EstadoAdjudicacion
                    })
                    .ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = adjudicadosDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        //BUSCA UN ADJUDICADO POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idAdjudicado:int}")]
        public IActionResult Obtener(int idAdjudicado)
        {
            try
            {
                // Buscar el adjudicado por ID y proyectar al DTO
                var adjudicadoDto = webcontext.Adjudicados
                    .Where(a => a.IdAdjudicado == idAdjudicado)
                    .Select(a => new AdjudicadoDTO
                    {
                        IdAdjudicado = a.IdAdjudicado,
                        IdRemate = a.IdRemate,
                        Nombres = a.Nombres,
                        Apellidos = a.Apellidos,
                        Rfc = a.Rfc,
                        Curp = a.Curp,
                        Telefono = a.Telefono,
                        Calle = a.Calle,
                        Num = a.Num,
                        Colonia = a.Colonia,
                        Municipio = a.Municipio,
                        Estado = a.Estado,
                        Cp = a.Cp,
                        SemafonoEscrituracion = a.SemafonoEscrituracion,
                        Consideraciones = a.Consideraciones,
                        EstadoAdjudicacion = a.EstadoAdjudicacion
                    })
                    .FirstOrDefault();

                if (adjudicadoDto == null)
                {
                    return BadRequest("Adjudicado no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = adjudicadoDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        //GUARDA UN NUEVO ADJUDICADO
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] AdjudicadoDTO newAdjudicado)
        {
            try
            {
                var objeto = new Adjudicado() 
                {
                    IdRemate = newAdjudicado.IdRemate,
                    Nombres = newAdjudicado.Nombres,
                    Apellidos = newAdjudicado.Apellidos,
                    Rfc = newAdjudicado.Rfc,
                    Curp = newAdjudicado.Curp,
                    Telefono = newAdjudicado.Telefono,
                    Calle = newAdjudicado.Calle,
                    Num = newAdjudicado.Num,
                    Colonia = newAdjudicado.Colonia,
                    Municipio = newAdjudicado.Municipio,
                    Estado = newAdjudicado.Estado,
                    Cp = newAdjudicado.Cp,
                    SemafonoEscrituracion = newAdjudicado.SemafonoEscrituracion,
                    Consideraciones = newAdjudicado.Consideraciones,
                    EstadoAdjudicacion = newAdjudicado.EstadoAdjudicacion,

                };

                webcontext.Adjudicados.Add(objeto);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        //EDITA DATOS DE UN ADJUDICADO
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] AdjudicadoDTO newAdjudicado)
        {
            Adjudicado adjudicados = webcontext.Adjudicados.Find(newAdjudicado.IdAdjudicado);

            if (adjudicados == null)
            {
                return BadRequest("Adjudicado no encontrado");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                adjudicados.IdRemate = newAdjudicado.IdRemate == 0 ? adjudicados.IdRemate : newAdjudicado.IdRemate;
                adjudicados.Nombres = newAdjudicado.Nombres is null ? adjudicados.Nombres : newAdjudicado.Nombres;
                adjudicados.Apellidos = newAdjudicado.Apellidos is null ? adjudicados.Apellidos : newAdjudicado.Apellidos;
                adjudicados.Rfc = newAdjudicado.Rfc is null ? adjudicados.Rfc : newAdjudicado.Rfc;
                adjudicados.Curp = newAdjudicado.Curp is null ? adjudicados.Curp : newAdjudicado.Curp;
                adjudicados.Telefono = newAdjudicado.Telefono is null ? adjudicados.Telefono : newAdjudicado.Telefono;
                adjudicados.Num = newAdjudicado.Num is null ? adjudicados.Num : newAdjudicado.Num;
                adjudicados.Colonia = newAdjudicado.Colonia is null ? adjudicados.Colonia : newAdjudicado.Colonia;
                adjudicados.Municipio = newAdjudicado.Municipio is null ? adjudicados.Municipio : newAdjudicado.Municipio;
                adjudicados.Estado = newAdjudicado.Estado is null ? adjudicados.Estado : newAdjudicado.Estado;
                adjudicados.Cp = newAdjudicado.Cp is null ? adjudicados.Cp : newAdjudicado.Cp;
                adjudicados.SemafonoEscrituracion = newAdjudicado.SemafonoEscrituracion is null ? adjudicados.SemafonoEscrituracion : newAdjudicado.SemafonoEscrituracion;
                adjudicados.Consideraciones = newAdjudicado.Consideraciones is null ? adjudicados.Consideraciones : newAdjudicado.Consideraciones;
                adjudicados.EstadoAdjudicacion = newAdjudicado.EstadoAdjudicacion is null ? adjudicados.EstadoAdjudicacion : newAdjudicado.EstadoAdjudicacion;

                webcontext.Adjudicados.Update(adjudicados);
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
            Adjudicado adjudicados = webcontext.Adjudicados.Find(idAdjudicado);

            if (adjudicados == null)
            {
                return BadRequest("Adjudicado no encontrado");
            }

            try
            {
                webcontext.Adjudicados.Remove(adjudicados);
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
