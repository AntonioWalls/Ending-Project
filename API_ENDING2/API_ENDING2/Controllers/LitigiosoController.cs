using API_ENDING2.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ENDING.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class LitigiosoController : ControllerBase
    {

        public readonly ProyectoWebContext webcontext;

        public LitigiosoController(ProyectoWebContext _context)
        {
            webcontext = _context;
        }

        //Muestra una lista de los litigios
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Litigioso> litigiosos = new List<Litigioso>();

            try
            {
                litigiosos = webcontext.Litigiosos.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = litigiosos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = litigiosos });
            }
        }

        //BUSCA UN Litigio POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idLitigioso:int}")]
        public IActionResult Obtener(int idLitigioso)
        {
            //busca dentro de la tabla inmobiliaria por medio del web context usando el idInmobiliaria
            Litigioso litigiosos = webcontext.Litigiosos.Find(idLitigioso);

            if (litigiosos == null)
            {
                return BadRequest("Litigioso no encontrada");
            }

            try
            {
                //llama al objeto inmobiliarias y usando al webcontext incluye los remates de la inmobiliaria que se buscó por medio del id de la inmobiliaria
                //y en caso de que encuntre datos, manda el primero, en caso contrario, va a mandar un nulo
                litigiosos = webcontext.Litigiosos.Where(i => i.IdLitigioso == idLitigioso).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = litigiosos });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = litigiosos });
            }
        }

        //Crea un nuevo litigioso
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Litigioso objeto)
        {
            try
            {
                webcontext.Litigiosos.Add(objeto);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });

            }
        }

        //EDITA DATOS DEl LITIGIOSO
        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Litigioso objeto)
        {
            Litigioso litigiosos = webcontext.Litigiosos.Find(objeto.IdLitigioso);

            if (litigiosos == null)
            {
                return BadRequest("Litigioso no encontrada");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                litigiosos.Nombres = objeto.Nombres is null ? litigiosos.Nombres : objeto.Nombres;
                litigiosos.Apellidos = objeto.Apellidos is null ? litigiosos.Apellidos : objeto.Apellidos;
                litigiosos.Curp = objeto.Curp is null ? litigiosos.Curp : objeto.Curp;
                litigiosos.Telefono = objeto.Telefono is null ? litigiosos.Telefono : objeto.Telefono;
                litigiosos.Calle = objeto.Calle is null ? litigiosos.Calle : objeto.Calle;
                litigiosos.Num = objeto.Num is null ? litigiosos.Num : objeto.Num;
                litigiosos.Colonia = objeto.Colonia is null ? litigiosos.Colonia : objeto.Colonia;
                litigiosos.Municipio = objeto.Municipio is null ? litigiosos.Municipio : objeto.Municipio;
                litigiosos.Estado = objeto.Estado is null ? litigiosos.Estado : objeto.Estado;
                litigiosos.Cp = objeto.Cp is null ? litigiosos.Cp : objeto.Cp;

                webcontext.Litigiosos.Update(litigiosos);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        //Elimina datos de un Litigioso por medio de un ID
        [HttpDelete]
        [Route("Eliminar/{idLitigioso:int}")]
        public IActionResult Eliminar(int idLitigioso)
        {
            Litigioso litigiosos = webcontext.Litigiosos.Find(idLitigioso);

            if (litigiosos == null)
            {
                return BadRequest("Litigioso no encontrada");
            }

            try
            {
                webcontext.Litigiosos.Remove(litigiosos);
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
