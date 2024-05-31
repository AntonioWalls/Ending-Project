using API_ENDING2.DTO;
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
            Litigioso litigiosos = webcontext.Litigiosos.Where(i => i.IdLitigioso == idLitigioso).FirstOrDefault();

            if (litigiosos == null)
            {
                return BadRequest("Litigioso no encontrado");
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
        public IActionResult Guardar([FromBody] LitigiosoDTO newLitigioso)
        {
            try
            {
                var objeto = new Litigioso(){
                    Nombres = newLitigioso.Nombres,
                    Apellidos = newLitigioso.Apellidos,
                    Rfc = newLitigioso.Rfc,
                    Curp = newLitigioso.Curp,
                    Telefono = newLitigioso.Telefono,
                    Calle = newLitigioso.Calle,
                    Num = newLitigioso.Num,
                    Colonia = newLitigioso.Colonia,
                    Municipio = newLitigioso.Municipio,
                    Estado = newLitigioso.Estado,
                    Cp = newLitigioso.Cp,
                };
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
        public IActionResult Editar([FromBody] LitigiosoDTO newLitigioso)
        {
            Litigioso litigiosos = webcontext.Litigiosos.Find(newLitigioso.IdLitigioso);

            if (litigiosos == null)
            {
                return BadRequest("Litigioso no encontrado");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                litigiosos.Nombres = newLitigioso.Nombres is null ? litigiosos.Nombres : newLitigioso.Nombres;
                litigiosos.Apellidos = newLitigioso.Apellidos is null ? litigiosos.Apellidos : newLitigioso.Apellidos;
                litigiosos.Curp = newLitigioso.Curp is null ? litigiosos.Curp : newLitigioso.Curp;
                litigiosos.Telefono = newLitigioso.Telefono is null ? litigiosos.Telefono : newLitigioso.Telefono;
                litigiosos.Calle = newLitigioso.Calle is null ? litigiosos.Calle : newLitigioso.Calle;
                litigiosos.Num = newLitigioso.Num is null ? litigiosos.Num : newLitigioso.Num;
                litigiosos.Colonia = newLitigioso.Colonia is null ? litigiosos.Colonia : newLitigioso.Colonia;
                litigiosos.Municipio = newLitigioso.Municipio is null ? litigiosos.Municipio : newLitigioso.Municipio;
                litigiosos.Estado = newLitigioso.Estado is null ? litigiosos.Estado : newLitigioso.Estado;
                litigiosos.Cp = newLitigioso.Cp is null ? litigiosos.Cp : newLitigioso.Cp;

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
                return BadRequest("Litigioso no encontrado");
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
