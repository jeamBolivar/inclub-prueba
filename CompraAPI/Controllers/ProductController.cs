using System.Collections.Generic;
using CompraAPI.Model;
using CompraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class ProductController
    {
        private readonly ProductRepository _productRepository;

        public ProductController()
        {
            _productRepository = new ProductRepository();
        }

        [HttpGet]
        public IEnumerable<Product> GetAllProducts()
        {
            return _productRepository.GetAll();
        }
        [HttpGet("{id}")]
        public Product GetProduct(int id)
        {
            return _productRepository.GetById(id);
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