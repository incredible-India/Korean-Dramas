using System.ComponentModel.DataAnnotations;

namespace Korean_Api.Models
{
    public class Movies
    {
        [Key]
        public int Id { get; set; }
        public int ActorId { get; set; }
        public string movies { get; set; }
    }

   

}
