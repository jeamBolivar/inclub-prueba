using System.ComponentModel.DataAnnotations;

namespace CompraAPI.Model  
{
    public class User
    {
        [Key]
        public int id {get; set;}
        public string username {get; set;}
        public string password {get; set;}
        
    }
}