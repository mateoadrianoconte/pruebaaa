using CodeFirstWebAPI.Repositories;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace CodeFirstWebAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrdersController : ControllerBase
    {
        private IRepository _repository;

        public OrdersController(IRepository repository)
        {
            _repository = repository;
        }

        [HttpGet()]
        public IActionResult GetByFilters(string client)
        {
            try
            {
                return Ok(_repository.GetByFilters(client));
            }catch(Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error interno!" });
            }
        }

        [HttpGet("{id}")]
        public IActionResult GetById(int id)
        {
            try
            {
                var order = _repository.GetOrderById(id);
                if (order == null)
                    return NotFound(new { mensaje = "Order no encontrada" });
                return Ok(order);
            }
            catch (Exception ex)
            {
                return StatusCode(StatusCodes.Status500InternalServerError, new { mensaje = "Error interno!" });
            }
        }

    }
}
