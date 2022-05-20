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
    public class ReportController
    {
        private readonly IReportRepository _reportRepository;

        public ReportController(IReportRepository reportRepository)
        {
            _reportRepository = reportRepository;
        }

        
        [HttpGet("{userId}")]
        public async Task<IEnumerable<Order>> GetOrdersByUser(int userId)
        {
            return await _reportRepository.GetAllOrderByUser(userId);
        }          

    }
}