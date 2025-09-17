using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebAPI.Models
{
    public class ItemOrder
    {
        public int Id { get; set; }

        public int Quantity { get; set; }
        //FK a Product.Id
        public int ProductId { get; set; }
        public Product Product { get; set; } 
    }
}
