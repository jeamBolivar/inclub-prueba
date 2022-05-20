using System.Collections.Generic;
using System.Threading.Tasks;
using CompraAPI.Interfaces;
using CompraAPI.Model;
using CompraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class OrderController
    {
        private readonly IOrderRepository _orderRepository;

        public OrderController(IOrderRepository orderRepository)
        {
            _orderRepository = orderRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Order>> GetAllOrders()
        {
            return await _orderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public async Task<Order> GetOrder(int id)
        {
            return await _orderRepository.GetById(id);
        }              

        [HttpPost]
        public void CreateOrder([FromBody]Order order)
        {
            _orderRepository.Add(order);
        }

        [HttpPut("{id}")]
        public void UpdateOrder(int id,[FromBody]Order order)
        {
            order.id = id;
            _orderRepository.Update(order);
        }

        [HttpDelete]
        public void DeleteOrder(int id)
        {
            _orderRepository.Delete(id);
        }

    }
}