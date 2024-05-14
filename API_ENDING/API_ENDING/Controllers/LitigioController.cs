using API_ENDING.Models;
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
            List<Litigio> litigios = new List<Litigio>();

            try
            {
                litigios = webcontext.Litigios.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = litigios });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = litigios });
            }
        }

        //BUSCA UN Litigio POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idLitigio:int}")]
        public IActionResult Obtener(int idLitigio)
        {
            //busca dentro de la tabla inmobiliaria por medio del web context usando el idInmobiliaria
            Litigio litigios = webcontext.Litigios.Find(idLitigio);

            if (litigios == null)
            {
                return BadRequest("Inmobiliaria no encontrada");
            }

            try
            {
                //llama al objeto inmobiliarias y usando al webcontext incluye los remates de la inmobiliaria que se buscó por medio del id de la inmobiliaria
                //y en caso de que encuntre datos, manda el primero, en caso contrario, va a mandar un nulo
                litigios = webcontext.Litigios.Where(i => i.IdLitigio == idLitigio).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = litigios });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = litigios });
            }
        }

        //GUARDA UN NUEVO LITIGIO
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Litigio objeto)
        {
            try
            {
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
        [HttpPost]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Litigio objeto)
        {
            Litigio litigios = webcontext.Litigios.Find(objeto.IdLitigio);

            if (litigios == null)
            {
                return BadRequest("Litigio no encontrado");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                litigios.Procedimiento = objeto.Procedimiento is null ? litigios.Procedimiento : objeto.Procedimiento;
                litigios.Juzgado = objeto.Juzgado is null ? litigios.Juzgado : objeto.Juzgado;
                litigios.Expediente = objeto.Expediente is null ? litigios.Expediente : objeto.Expediente;
                litigios.EdoJuzgado = objeto.EdoJuzgado is null ? litigios.EdoJuzgado : objeto.EdoJuzgado;
                litigios.AdeudoTotal = objeto.AdeudoTotal is null ? litigios.AdeudoTotal : objeto.AdeudoTotal;

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
                return BadRequest("Adjudicado no encontrada");
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
