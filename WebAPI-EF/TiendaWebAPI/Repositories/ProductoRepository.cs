using TiendaWebAPI.Models;

namespace TiendaWebAPI.Repositories
{
    public class ProductoRepository : IProductoRepository
    {
        private TiendaContext _contex;

        public ProductoRepository(TiendaContext contex)
        {
            _contex = contex;
        }

        public bool Create(Producto producto)
        {
            _contex.Productos.Add(producto);
            return _contex.SaveChanges() > 0;
        }

        public bool Delete(int id)
        {
            var prod = GetById(id);
            if (prod != null)
            {
                _contex.Productos.Remove(prod);
                return _contex.SaveChanges() > 0;
            }

            return false;
        }

        public List<Producto> GetAll()
        {
            return _contex.Productos.ToList();
        }

        public Producto? GetById(int id)
        {
            return _contex.Productos.Find(id);
        }

        public bool Update(Producto producto)
        {
            _contex.Productos.Update(producto);
            return _contex.SaveChanges() > 0;
        }
    }
}
