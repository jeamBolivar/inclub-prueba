using System.ComponentModel.DataAnnotations;

namespace CompraAPI.Model
{
    public class Product
    {
        [Key]
        public int id {get; set;}
        public string description {get; set;}
        public float price {get; set;}
    }
}