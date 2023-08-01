using System.ComponentModel.DataAnnotations;

namespace Korean_Api.Models
{
    public class TopMovies
    {
        [Key]
        public int Id { get; set; }
      
        public string ActorName { get; set; }
        public string ShowType { get; set; }

        public string MovieName { get; set; }

    }
}
