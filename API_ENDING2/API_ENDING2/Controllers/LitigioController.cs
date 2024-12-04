using API_ENDING2.DTO;
using API_ENDING2.Models;
using API_ENDING2.Services;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ENDING.Controllers
{
    [EnableCors ("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class LitigioController : ControllerBase
    {
        public readonly ProyectoWebContext webcontext;

        public LitigioController(ProyectoWebContext _context)
        {
            webcontext = _context;
        }

        //Muestra una lista de los litigios
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            try
            {
                // Proyección a DTO
                var litigioDto = webcontext.Litigios
                    .Select(i => new LitigioDTO
                    {
                       IdLitigio = i.IdLitigio,
                       IdLitigioso = i.IdLitigioso,
                       IdRemate = i.IdRemate,
                       Procedimiento = i.Procedimiento,
                       Juzgado = i.Juzgado,
                       Expediente = i.Expediente,
                       EdoJuzgado = i.EdoJuzgado,
                       AdeudoTotal = i.AdeudoTotal
                    })
                    .ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = litigioDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        //BUSCA UN Litigio POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idLitigio:int}")]
        public IActionResult Obtener(int idLitigio)
        {
            try
            {
                // Buscar el litigio por ID y proyectar al DTO
                var litigioDto = webcontext.Litigios
                    .Where(l => l.IdLitigio == idLitigio)
                    .Select(l => new LitigioDTO
                    {
                        IdLitigio = l.IdLitigio,
                        IdLitigioso = l.IdLitigioso,
                        IdRemate = l.IdRemate,
                        Procedimiento = l.Procedimiento,
                        Juzgado = l.Juzgado,
                        Expediente = l.Expediente,
                        EdoJuzgado = l.EdoJuzgado,
                        AdeudoTotal = l.AdeudoTotal
                    })
                    .FirstOrDefault();

                if (litigioDto == null)
                {
                    return BadRequest("Litigio no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = litigioDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }


        //GUARDA UN NUEVO LITIGIO
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] LitigioDTO newLitigio)
        {
            try
            {
                var objeto = new Litigio() 
                {
                    IdLitigioso = newLitigio.IdLitigioso,
                    IdRemate = newLitigio.IdRemate,
                    Procedimiento = newLitigio.Procedimiento,
                    Juzgado = newLitigio.Juzgado,
                    Expediente = newLitigio.Expediente,
                    EdoJuzgado = newLitigio.EdoJuzgado,
                    AdeudoTotal = newLitigio.AdeudoTotal,
                };

                webcontext.Litigios.Add(objeto);
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
        public IActionResult Editar([FromBody] LitigioDTO newLitigio)
        {
            Litigio litigios = webcontext.Litigios.Find(newLitigio.IdLitigio);

            if (litigios == null)
            {
                return BadRequest("Litigio no encontrado");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                litigios.IdLitigioso = newLitigio.IdLitigioso == 0 ? litigios.IdLitigioso : newLitigio.IdLitigioso;
                litigios.IdRemate = newLitigio.IdRemate == 0 ? litigios.IdRemate : newLitigio.IdRemate;
                litigios.Procedimiento = newLitigio.Procedimiento is null ? litigios.Procedimiento : newLitigio.Procedimiento;
                litigios.Juzgado = newLitigio.Juzgado is null ? litigios.Juzgado : newLitigio.Juzgado;
                litigios.Expediente = newLitigio.Expediente is null ? litigios.Expediente : newLitigio.Expediente;
                litigios.EdoJuzgado = newLitigio.EdoJuzgado is null ? litigios.EdoJuzgado : newLitigio.EdoJuzgado;
                litigios.AdeudoTotal = newLitigio.AdeudoTotal is null ? litigios.AdeudoTotal : newLitigio.AdeudoTotal;

                webcontext.Litigios.Update(litigios);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        //Elimina datos de un Litigio por medio de un ID
        [HttpDelete]
        [Route("Eliminar/{idLitigio:int}")]
        public IActionResult Eliminar(int idLitigio)
        {
            Litigio litigios = webcontext.Litigios.Find(idLitigio);

            if (litigios == null)
            {
                return BadRequest("Litigio no encontrado");
            }

            try
            {
                webcontext.Litigios.Remove(litigios);
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
