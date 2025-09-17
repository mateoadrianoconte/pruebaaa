using CodeFirstWebAPI.Models;

namespace CodeFirstWebAPI.Repositories
{
    public interface IRepository
    {
        List<Order> GetByFilters(string client);
        Order? GetOrderById(int id);
    }
}
