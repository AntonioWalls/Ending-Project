using API_ENDING.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;
using Microsoft.EntityFrameworkCore;

namespace API_ENDING.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class IncluyeController : ControllerBase
    {

        public readonly ProyectoWebContext webcontext;

        public IncluyeController(ProyectoWebContext _context)
        {
            webcontext = _context;
        }

        //Muestra una lista de los adjudicados
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Incluye> incluyes = new List<Incluye>();

            try
            {
                incluyes = webcontext.Incluyes
                    .Include(i => i.oPropiedad)
                    .Include(i => i.oLitigioso)
                    .Include(i => i.oLitigio)
                    .Include(i => i.oAdjudicado)
                    .ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = incluyes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = incluyes });
            }
        }


        //EDITA DATOS DE UNA RELACION
        [HttpPut]
        [Route("Editar")]
        public IActionResult EditarIncluye([FromBody] Incluye objeto)
        {
            // Buscar el registro en la tabla Incluye
            var incluye = webcontext.Incluyes
                .FirstOrDefault(i => i.IdPropiedad == objeto.IdPropiedad);

            if (incluye == null)
            {
                return BadRequest("Registro no encontrado");
            }

            try
            {
                // Guardar los valores actuales de IdLitigioso, IdLitigio e IdAdjudicado
                var idLitigiosoActual = incluye.IdLitigioso;
                var idLitigioActual = incluye.IdLitigio;
                var idAdjudicadoActual = incluye.IdAdjudicado;

                // Eliminar el registro existente
                webcontext.Incluyes.Remove(incluye);
                webcontext.SaveChanges();

                // Crear un nuevo registro con los nuevos valores
                var nuevoIncluye = new Incluye
                {
                    IdPropiedad = objeto.IdPropiedad,
                    IdLitigioso = objeto.IdLitigioso == 0 ? idLitigiosoActual : objeto.IdLitigioso,
                    IdLitigio = objeto.IdLitigio == 0 ? idLitigioActual : objeto.IdLitigio,
                    IdAdjudicado = objeto.IdAdjudicado == 0 ? idAdjudicadoActual : objeto.IdAdjudicado
                };

                webcontext.Incluyes.Add(nuevoIncluye);
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
        [HttpGet]
        [Route("max")]
        public IActionResult Max_register()
        {
            List<Incluye> incluyes = new List<Incluye>();
            incluyes = webcontext.Incluyes.ToList();
            int incluyeCounter = incluyes.Count;

            try
            {
                if (incluyeCounter > 0)
                {
                    return StatusCode(StatusCodes.Status200OK, new { mensaje = "el total de los registros es:", Response = incluyeCounter });
                }
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
            return StatusCode(StatusCodes.Status200OK, new { mensaje = "No hay registros en la lista" });


        }


    }
}
