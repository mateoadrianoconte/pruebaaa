using CarpinteriaApp.dominio;

namespace DataAPI.fachada
{
    public interface IDataApi
    {
        public List<Producto> GetProductos();
        public bool SavePresupuesto(Presupuesto presupuesto);
    }
}
