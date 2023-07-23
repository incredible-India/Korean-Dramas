using System.ComponentModel.DataAnnotations;

namespace Korean_Api.Models
{
    public class Users
    {
        [Key]
        public int id { get; set; }

        public string Name { get; set; }

        public string Email { get; set; }

        public string Password { get; set; }


    }
}
