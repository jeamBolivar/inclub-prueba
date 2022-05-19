using CompraAPI.Model;
using CompraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        private readonly OrderRepository _orderRepository;

        public OrderController()
        {
            _orderRepository = new OrderRepository();
        }       

        [HttpPost]
        public void CreateOrder([FromBody]Order order)
        {
            _orderRepository.Add(order);
        }

    }
}