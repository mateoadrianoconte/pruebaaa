using ProduccionBack.Entities;

namespace ProduccionBack.Data
{
    public interface IOrdenRepository
    {
        bool CrearOrden(OrdenProduccion orden);

        List<OrdenProduccion> ObtenerOrdenes(DateTime? fecha, string estado);

        bool CancelarOrden(int nro);
    }
}
