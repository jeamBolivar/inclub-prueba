using System.Collections.Generic;
using CompraAPI.Model;
using CompraAPI.Repositories;
using Microsoft.AspNetCore.Mvc;

namespace CompraAPI.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController
    {
        private readonly UserRepository _userRepository;

        public UserController()
        {
            _userRepository = new UserRepository();
        }

        [HttpGet]
        public IEnumerable<User> GetAllUsers()
        {
            return _userRepository.GetAll();
        }
        [HttpGet("{id}")]
        public User GetUser(int id)
        {
            return _userRepository.GetById(id);
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