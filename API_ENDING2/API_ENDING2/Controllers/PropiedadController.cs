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
        public IActionResult Guardar([FromBody] PropiedadDTO newPropiedad)
        {
            try
            {
                var objeto = new Propiedad()
                {
                    //RazonSocial = newInmobiliaria.RazonSocial,
                    Calle = newPropiedad.Calle,
                    Num = newPropiedad.Num,
                    Colonia = newPropiedad.Colonia,
                    Municipio = newPropiedad.Municipio,
                    Estado = newPropiedad.Estado,
                    Cp = newPropiedad.Cp,
                    Subtipo = newPropiedad.Subtipo,
                    Latitud = newPropiedad.Latitud,
                    Altitud = newPropiedad.Altitud,
                    SuperficieTerreno = newPropiedad.SuperficieTerreno,
                    SuperficieCons = newPropiedad.SuperficieCons,

                };
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
        public IActionResult Editar([FromBody] PropiedadDTO newPropiedad)
        {
            Propiedad propiedades = webcontext.Propiedads.Find(newPropiedad.IdPropiedad);

            if (propiedades == null)
            {
                return BadRequest("Propiedad no encontrada");
            }

            try
            {
                //valida si el campo que va cambiar el usuario, queda vacio, lo rellena con el dato
                //que ya existia en la base de datos
                //quiero editar solo el telefono, ps telefono cambia y los demás datos quedan igual
                propiedades.Calle = newPropiedad.Calle is null ? propiedades.Calle : newPropiedad.Calle;
                propiedades.Num = newPropiedad.Num is null ? propiedades.Num : newPropiedad.Num;
                propiedades.Colonia = newPropiedad.Colonia is null ? propiedades.Colonia : newPropiedad.Colonia;
                propiedades.Municipio = newPropiedad.Municipio is null ? propiedades.Municipio : newPropiedad.Municipio;
                propiedades.Estado = newPropiedad.Estado is null ? propiedades.Estado : newPropiedad.Estado;
                propiedades.Cp = newPropiedad.Cp is null ? propiedades.Cp : newPropiedad.Cp;
                propiedades.Subtipo = newPropiedad.Subtipo is null ? propiedades.Subtipo : newPropiedad.Subtipo;
                propiedades.Latitud = newPropiedad.Latitud is null ? propiedades.Latitud : newPropiedad.Latitud;
                propiedades.Altitud = newPropiedad.Altitud is null ? propiedades.Altitud : newPropiedad.Altitud;
                propiedades.SuperficieTerreno = newPropiedad.SuperficieTerreno is null ? propiedades.SuperficieTerreno : newPropiedad.SuperficieTerreno;
                propiedades.SuperficieCons = newPropiedad.SuperficieCons is null ? propiedades.SuperficieCons : newPropiedad.SuperficieCons;

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
                return BadRequest("Propiedad no encontrada");
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
