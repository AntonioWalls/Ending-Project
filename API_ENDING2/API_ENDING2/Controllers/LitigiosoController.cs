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
            try
            {
                // Proyección a DTO
                var litigiosoDto = webcontext.Litigiosos
                    .Select(i => new LitigiosoDTO
                    {
                        IdLitigioso = i.IdLitigioso,
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
                        
                    })
                    .ToList(); return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = litigiosoDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
            }
        }

        //BUSCA UN Litigioso POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idLitigioso:int}")]
        public IActionResult Obtener(int idLitigioso)
        {
            try
            {
                // Buscar el litigioso por ID y proyectar al DTO
                var litigiosoDto = webcontext.Litigiosos
                    .Where(l => l.IdLitigioso == idLitigioso)
                    .Select(l => new LitigiosoDTO
                    {
                        IdLitigioso = l.IdLitigioso,
                        Nombres = l.Nombres,
                        Apellidos = l.Apellidos,
                        Rfc = l.Rfc,
                        Curp = l.Curp,
                        Telefono = l.Telefono,
                        Calle = l.Calle,
                        Num = l.Num,
                        Colonia = l.Colonia,
                        Municipio = l.Municipio,
                        Estado = l.Estado,
                        Cp = l.Cp
                    })
                    .FirstOrDefault();

                if (litigiosoDto == null)
                {
                    return BadRequest("Litigioso no encontrado");
                }

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = litigiosoDto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.Message });
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
