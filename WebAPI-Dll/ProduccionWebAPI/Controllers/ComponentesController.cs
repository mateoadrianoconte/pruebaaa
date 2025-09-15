using Microsoft.AspNetCore.Mvc;
using ProduccionBack.Data;
using ProduccionBack.Services;

// For more information on enabling Web API for empty projects, visit https://go.microsoft.com/fwlink/?LinkID=397860

namespace ProduccionWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ComponentesController : ControllerBase
    {
        private IComponenteService _service;

        public ComponentesController(IComponenteService service)
        {
            _service = service;
        }

        // GET: api/<ComponentesController>
        [HttpGet]
        public IActionResult Get()
        {
            try
            {
                return Ok(_service.GetAll());
            }
            catch (Exception)
            {

                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error al acceder a datos" });
            }
        }
    }
}