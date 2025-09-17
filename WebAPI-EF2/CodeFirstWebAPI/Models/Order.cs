namespace CodeFirstWebAPI.Models
{
    public class Order
    {
        public int Id { get; set; }
        public string Customer { get; set; } = string.Empty;
        public DateTime Date { get; set; }

        public virtual ICollection<ItemOrder> Items { get; set; } = new List<ItemOrder>();
    }
}
