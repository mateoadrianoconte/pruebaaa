using CodeFirstWebAPI.Models;
using Microsoft.EntityFrameworkCore;

namespace CodeFirstWebAPI.Repositories
{

    public class OrderRepository : IRepository
    {
        private OrderContext _context;

        public OrderRepository(OrderContext context)
        {
            _context = context;
        }


        public List<Order> GetByFilters(string client)
        {
            //Recuperar solo las ordenes cuyo cliente contiene la cadena 'client'
            var orders = _context.Orders.Where(x => x.Customer.Contains(client)).ToList();
            return orders;
        }


        public Order? GetOrderById(int id)
        {
            //Recuperar por id la Order junto con los detalles y de cada detalle el producto asociado:
            var order = _context.Orders.Include(x => x.Items).ThenInclude(y => y.Product).FirstOrDefault(x => x.Id == id);
            return order;

        }
    }
}
