using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

using Microsoft.EntityFrameworkCore;
using API_PRUEBAS.Models;

using Microsoft.AspNetCore.Cors;


namespace API_PRUEBAS.Controllers
{
    [EnableCors("ReglasCors")]
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {

        public readonly DbapiContext _dbcontext; //con este dbcontext vamos a poder hacer los CRUD

        public ProductoController(DbapiContext _context)
        {
            _dbcontext = _context;
        }


        //ESTA COSA DE AQUÍ ES LA API LISTA que muestra una lista de los productos de la base de datos

        [HttpGet]
        [Route("Lista")]
        public IActionResult Lista() {
            List<Producto> lista = new List<Producto>();

            try
            { //Muestra una lista de todos los productos junto a los datos de la tabla categoría por medio del objeto categoría
                lista = _dbcontext.Productos.Include(c => c.oCategoria).ToList();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = lista });
            }
            catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = lista });
            }

        }

        //vamos a devolver un producto por un ID

        [HttpGet]
        [Route("Obtener/{idProducto:int}")]
        public IActionResult Obtener(int idProducto)
        {
            Producto oProducto = _dbcontext.Productos.Find(idProducto);

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }


            try
            { //Muestra una lista de todos los productos junto a los datos de la tabla categoría por medio del objeto categoría
               oProducto =_dbcontext.Productos.Include(c => c.oCategoria).Where(p => p.IdProducto == idProducto).FirstOrDefault();
                

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok", response = oProducto });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message, response = oProducto });
            }

        }

        //AHORA VAMOS A GUARDAR UN PRODUCTO
        [HttpPost]
        [Route("Guardar")]
        public IActionResult Guardar([FromBody]Producto objeto)
        {
            try
            {
                _dbcontext.Productos.Add(objeto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok"});
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        //AHORA VAMOS A EDITAR UN PRODUCTO

        [HttpPut]
        [Route("Editar")]
        public IActionResult Editar([FromBody] Producto objeto)
        {
            Producto oProducto = _dbcontext.Productos.Find(objeto.IdProducto);
            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                //Aquí lo que hace es:
                // En el caso de que un objeto no tenga ningún valor, va a mantener la información que ya mantiene en ese campo
                // caso contrario ps va a cambiar el dato verdah

                oProducto.CodigoBarra = objeto.CodigoBarra is null ? oProducto.CodigoBarra : objeto.CodigoBarra;
                oProducto.Descripcion = objeto.Descripcion is null ? oProducto.Descripcion : objeto.Descripcion;
                oProducto.Marca = objeto.Marca is null ? oProducto.Marca : objeto.Marca;
                oProducto.IdCategoria = objeto.IdCategoria is null ? oProducto.IdCategoria : objeto.IdCategoria;
                oProducto.Precio = objeto.Precio is null ? oProducto.Precio : objeto.Precio;



                _dbcontext.Productos.Update(oProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new { mensaje = ex.Message });
            }
        }

        [HttpDelete]
        [Route("Eliminar/{idProducto:int}")]
        public IActionResult Eliminar(int idProducto)
        {
            Producto oProducto = _dbcontext.Productos.Find(idProducto);

            if (oProducto == null)
            {
                return BadRequest("Producto no encontrado");
            }

            try
            {
                _dbcontext.Productos.Remove(oProducto);
                _dbcontext.SaveChanges();

                return StatusCode(StatusCodes.Status200OK, new { mensaje = "ok" });
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status200OK, new {mensaje = ex.Message});
            }

        }

    }
}
