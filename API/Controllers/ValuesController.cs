using API.Comun.Modelos;
using Microsoft.AspNetCore.Mvc;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ValuesController : ControllerBase
    {
        // GET: api/<ValuesController>
        [HttpGet]
        public IEnumerable<itemUsuariosDto> Get()
        {
            //Esto es para dar respuesta de la api
            IEnumerable<itemUsuariosDto> values = new List<itemUsuariosDto>();
            itemUsuariosDto itemUsuariosDto = new itemUsuariosDto();
            itemUsuariosDto.nombre = "A";
            itemUsuariosDto.apellidos = "A";
            values.Append(itemUsuariosDto);
            return values;

        }

        // GET api/<ValuesController>/5
        [HttpGet("{id}")]
        public string Get(int id)
        {
            return "value";
        }

        // POST api/<ValuesController>
        [HttpPost]
        public void Post([FromBody] string value)
        {
        }

        // PUT api/<ValuesController>/5
        [HttpPut("{id}")]
        public void Put(int id, [FromBody] string value)
        {
        }

        // DELETE api/<ValuesController>/5
        [HttpDelete("{id}")]
        public void Delete(int id)
        {
        }
    }
}
