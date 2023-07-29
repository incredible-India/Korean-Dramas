using System.ComponentModel.DataAnnotations;

namespace Korean_Api.Models
{
    public class Details
    {
        [Key]
        public int Id { get; set; }
        public int ActorId { get; set; }

        public string Detail { get; set; }


    }
}
