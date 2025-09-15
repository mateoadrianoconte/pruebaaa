using Microsoft.AspNetCore.Mvc;
using Newtonsoft.Json.Linq;
using TiendaWebAPI.Models;
using TiendaWebAPI.Repositories;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace TiendaWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductoController : ControllerBase
    {
        private IProductoRepository _repository;

        public ProductoController(IProductoRepository repository)
        {
            _repository = repository;
        }

        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_repository.GetAll());
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al recuperar productos" });
            }
        }

        // GET api/<ProductoController>/5
        [HttpGet("{id}")]
        public IActionResult Get(int id)
        {
            try
            {
                var prod = _repository.GetById(id);
                if (prod == null)
                    return NotFound(new { mensaje = $"Producto ID: {id} NO encontrado!" });
                return Ok(prod);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al actualizar producto" });
            }
        }

        // POST api/<ProductoController>
        [HttpPost]
        public IActionResult Post([FromBody] Producto value)
        {
            try
            {
                if (value == null)
                    return BadRequest(new { mensaje = "Error. Faltan datos requeridos!" });
                _repository.Create(value);
                return CreatedAtAction(nameof(Get), new  { id = value.Id}, value);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al crear producto!" });
            }
        }

        // PUT api/<ProductoController>/5
        [HttpPut("{id}")]
        public IActionResult Put(int id, [FromBody] Producto value)
        {
            try
            {
                if (value == null)
                    return BadRequest(new { mensaje = "Error. Faltan datos requeridos!" });

                var prod = _repository.GetById(id);
                if ( prod == null)
                    return NotFound(new { mensaje = "Producto no encontrado!" });
                prod.Nombre = value.Nombre;
                prod.Precio = value.Precio;
                prod.FechaBaja = value.FechaBaja;
                prod.MotivoBaja = value.MotivoBaja;

                _repository.Update(prod);
                return Ok(value);
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al actualizar producto!" });
            }
        }

        // DELETE api/<ProductoController>/5
        [HttpDelete("{id}")]
        public IActionResult Delete(int id)
        {
            try
            {
                if (_repository.GetById(id) == null)
                    return NotFound(new { mensaje = "Producto no encontrado!" });

                _repository.Delete(id);
                return Ok(new { mensaje = "Producto eliminado!"});
            }
            catch (Exception)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al borrar el producto!" });
            }
        }
    }
}
