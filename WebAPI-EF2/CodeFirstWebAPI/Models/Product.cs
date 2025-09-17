using System.ComponentModel.DataAnnotations;

namespace CodeFirstWebAPI.Models
{
    public class Product
    {
        public int Id { get; set; }
        [Required]
        public string Nombre { get; set; } = string.Empty;
        public int Stock { get; set; } = 1;
        public float Precio { get; set; }

    }
}
