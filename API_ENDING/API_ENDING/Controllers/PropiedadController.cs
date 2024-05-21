using API_ENDING.Models;
using Microsoft.AspNetCore.Cors;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace API_ENDING.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class PropiedadController : ControllerBase
    {
        public readonly ProyectoWebContext webcontext;

        public PropiedadController(ProyectoWebContext _context)
        {
            webcontext = _context;
        }

        //Muestra una lista de las propiedades
        [HttpGet]
        [Route("lista")]
        public IActionResult Lista()
        {
            List<Propiedad> propiedades = new List<Propiedad>();

            try
            {
                propiedades = webcontext.Propiedads.ToList();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = propiedades });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = propiedades });
            }
        }

        //BUSCA UNA PROPIEDAD POR MEDIO DE SU ID
        [HttpGet]
        [Route("Obtener/{idPropiedad:int}")]
        public IActionResult Obtener(int idPropiedad)
        {
            //busca dentro de la tabla inmobiliaria por medio del web context usando el idInmobiliaria
            Propiedad propiedades = webcontext.Propiedads.Find(idPropiedad);

            if (propiedades == null)
            {
                return BadRequest("Propiedad no encontrada");
            }

            try
            {
                //llama al objeto inmobiliarias y usando al webcontext incluye los remates de la inmobiliaria que se buscó por medio del id de la inmobiliaria
                //y en caso de que encuntre datos, manda el primero, en caso contrario, va a mandar un nulo
                propiedades = webcontext.Propiedads.Where(i => i.IdPropiedad == idPropiedad).FirstOrDefault();
                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", Response = propiedades });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, Response = propiedades });
            }
        }

        //Crea una nueva propiedad
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody] Propiedad objeto)
        {
            try
            {
                webcontext.Propiedads.Add(objeto);
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
        public IActionResult Editar([FromBody] Propiedad objeto)
        {
            Propiedad propiedades = webcontext.Propiedads.Find(objeto.IdPropiedad);

            if (propiedades == null)
            {
                return BadRequest("Propiedad no encontrada");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                propiedades.Calle = objeto.Calle is null ? propiedades.Calle : objeto.Calle;
                propiedades.Num = objeto.Num is null ? propiedades.Num : objeto.Num;
                propiedades.Colonia = objeto.Colonia is null ? propiedades.Colonia : objeto.Colonia;
                propiedades.Municipio = objeto.Municipio is null ? propiedades.Municipio : objeto.Municipio;
                propiedades.Estado = objeto.Estado is null ? propiedades.Estado : objeto.Estado;
                propiedades.Cp = objeto.Cp is null ? propiedades.Cp : objeto.Cp;
                propiedades.Subtipo = objeto.Subtipo is null ? propiedades.Subtipo : objeto.Subtipo;
                propiedades.Latitud = objeto.Latitud is null ? propiedades.Latitud : objeto.Latitud;
                propiedades.Altitud = objeto.Altitud is null ? propiedades.Altitud : objeto.Altitud;
                propiedades.SuperficieTerreno = objeto.SuperficieTerreno is null ? propiedades.SuperficieTerreno : objeto.SuperficieTerreno;
                propiedades.SuperficieCons = objeto.SuperficieCons is null ? propiedades.SuperficieCons : objeto.SuperficieCons;

                webcontext.Propiedads.Update(propiedades);
                webcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }


        //Elimina datos de una propiedad por medio de un ID
        [HttpDelete]
        [Route("Eliminar/{idPropiedad:int}")]
        public IActionResult Eliminar(int idPropiedad)
        {
            Propiedad propiedades = webcontext.Propiedads.Find(idPropiedad);

            if (propiedades == null)
            {
                return BadRequest("Litigioso no encontrada");
            }

            try
            {
                webcontext.Propiedads.Remove(propiedades);
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
