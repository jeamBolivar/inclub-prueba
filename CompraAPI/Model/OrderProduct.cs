using System.ComponentModel.DataAnnotations;

namespace CompraAPI.Model
{
    public class OrderProduct
    {
        [Key]
        public int id {get; set;}
        public int product_id {get; set;}
        public int quantity {get; set;}
    }
}