using System.Collections.Generic;
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

        [HttpGet]
        public IEnumerable<Order> GetAllOrders()
        {
            return _orderRepository.GetAll();
        }

        [HttpGet("{id}")]
        public Order GetOrder(int id)
        {
            return _orderRepository.GetById(id);
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