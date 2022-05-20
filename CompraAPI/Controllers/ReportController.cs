using System.Collections.Generic;
using CompraAPI.Model;
using CompraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ReportController
    {
        private readonly ReportRepository _reportRepository;

        public ReportController()
        {
            _reportRepository = new ReportRepository();
        }

        
        [HttpGet("{userId}")]
        public IEnumerable<Order> GetOrdersByUser(int userId)
        {
            return _reportRepository.GetAllOrderByUser(userId);
        }          

    }
}