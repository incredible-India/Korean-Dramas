using System.ComponentModel.DataAnnotations;

namespace Korean_Api.Models
{
    public class actorImage
    {
        [Key]
        public int Id { get; set; }

        public int ActorId { get; set; }

        public string Image { get; set; }
    }
}
