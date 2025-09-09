using ProduccionBack.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ProduccionBack.Services
{
    public interface IProduccionService
    {
        bool RegistrarProduccion(OrdenProduccion orden);
        List<OrdenProduccion> GetByFilters(DateTime? fecha, string estado);

        bool CancelarOrden(int nro);
    }
}
