using TiendaWebAPI.Models;

namespace TiendaWebAPI.Repositories
{
    public interface IProductoRepository
    {
        List<Producto> GetAll();
        Producto? GetById(int id);
        bool Create(Producto producto);
        bool Update(Producto producto);
        bool Delete(int id);
    }
}
