using CarpinteriaApp.dominio;
using DataAPI.datos;


namespace DataAPI.fachada
{
    public class DataApiImp : IDataApi
    {
        private IRepository repository;

        public DataApiImp()
        {
            repository = new PresupuestoRepository();
        }

        public List<Producto> GetProductos()
        {
            return repository.ObtenerProductos();
        }

        public bool SavePresupuesto(Presupuesto presupuesto)
        {
            return repository.Crear(presupuesto);
        }
    }
}
