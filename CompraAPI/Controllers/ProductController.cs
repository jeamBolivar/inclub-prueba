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
    public class ProductController
    {
        private readonly IProductRepository _productRepository;

        public ProductController(IProductRepository productRepository)
        {
            _productRepository = productRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<Product>> GetAllProducts()
        {
            return await _productRepository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<Product> GetProduct(int id)
        {
            return await _productRepository.GetById(id);
        }

        [HttpPost]
        public void CreateProduct([FromBody]Product product)
        {
            _productRepository.Add(product);
        }

        [HttpPut("{id}")]
        public void UpdateProduct(int id,[FromBody]Product product)
        {
            product.id = id;
            _productRepository.Update(product);
        }

        [HttpDelete]
        public void DeleteProduct(int id)
        {
            _productRepository.Delete(id);
        }
    }
}