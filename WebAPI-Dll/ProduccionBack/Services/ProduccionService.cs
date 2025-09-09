using ProduccionBack.Data;
using ProduccionBack.Entities;

namespace ProduccionBack.Services
{
    public class ProduccionService : IProduccionService
    {
        private IOrdenRepository _repository;
        public ProduccionService(IOrdenRepository repository)
        {
            _repository = repository;
        }

        public List<OrdenProduccion> GetByFilters(DateTime? fecha, string estado)
        {
            return _repository.ObtenerOrdenes(fecha, estado);
        }

        public bool RegistrarProduccion(OrdenProduccion orden)
        {
            return _repository.CrearOrden(orden);
        }

        public bool CancelarOrden(int nro)
        {
            return _repository.CancelarOrden(nro); 
        }
    }
}
