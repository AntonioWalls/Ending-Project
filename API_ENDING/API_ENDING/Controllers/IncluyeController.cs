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
                incluyes = webcontext.Incluyes.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = incluyes });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = incluyes });
            }
        }


        //EDITA DATOS DE UNA RELACION
        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Incluye objeto)
        {
            Incluye incluyes = webcontext.Incluyes.Find(objeto.IdPropiedad, objeto.IdLitigio, objeto.IdLitigioso, objeto.oAdjudicado);
            
            

            if (incluyes == null)
            {
                return BadRequest("relacion no encontrada");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                incluyes.IdPropiedad = objeto.IdPropiedad is >=1 ? incluyes.IdPropiedad : objeto.IdPropiedad;
                incluyes.IdAdjudicado = objeto.IdAdjudicado is >= 1 ? incluyes.IdAdjudicado : objeto.IdAdjudicado;
                incluyes.IdLitigio = objeto.IdLitigio is >= 1 ? incluyes.IdLitigio : objeto.IdLitigio;
                incluyes.IdLitigioso = objeto.IdLitigioso is >= 1 ? incluyes.IdLitigioso : objeto.IdLitigioso;

                webcontext.Incluyes.Update(incluyes);
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

