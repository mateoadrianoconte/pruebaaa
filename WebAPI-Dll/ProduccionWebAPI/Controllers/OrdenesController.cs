using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Data;
using ProduccionBack.Entities;
using ProduccionBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProduccionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdenesController : ControllerBase
    {
        private IProduccionService _service;

        public OrdenesController(IProduccionService service)
        {
            _service = service;
        }

        private bool IsOrdenValid(OrdenProduccion value)
        {
            return true;
        }

        // POST api/<OrdenesController>
        [HttpPost]
        public IActionResult Post([FromBody] OrdenProduccion? value)
        {
            try
            {
                if(value == null || !IsOrdenValid(value))
                {
                    return BadRequest(new { mensaje = "Orden de producción incorrecta!" });
                }
                if (_service.RegistrarProduccion(value))
                {
                    return Ok(new { mensaje = "Orden registrada con éxito!" });
                }
                else
                {
                    throw new Exception("Error de al grabar datos!");
                }

            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = ex.ToString() });
            }
        }

       
    }
}
