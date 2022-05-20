using System.Collections.Generic;
using System.Threading.Tasks;
using CompraAPI.Interfaces;
using CompraAPI.Model;
using Microsoft.AspNetCore.Mvc;

namespace CompraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly IUserRepository _userRepository;

        public UserController(IUserRepository userRepository)
        {
            _userRepository = userRepository;
        }

        [HttpGet]
        public async Task<IEnumerable<User>> GetAllUsers()
        {
            return await _userRepository.GetAll();
        }
        [HttpGet("{id}")]
        public async Task<User> GetUser(int id)
        {
            return await _userRepository.GetById(id);
        }

        [HttpPost]
        public void CreateUser([FromBody]User user)
        {
            _userRepository.Add(user);
        }

        [HttpPut("{id}")]
        public void UpdateUser(int id,[FromBody]User user)
        {
            user.id = id;
            _userRepository.Update(user);
        }

        [HttpDelete]
        public void DeleteUser(int id)
        {
            _userRepository.Delete(id);
        }

    }
}