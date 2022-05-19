using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;

namespace CompraAPI.Model
{
    public class Order
    {
        [Key]
        public int id {get; set;}
        public int user_id {get ;set;}   
        public List<OrderProduct> products {get; set;}

    }
}