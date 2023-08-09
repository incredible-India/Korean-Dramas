using System.Collections.Specialized;
using System.ComponentModel.DataAnnotations;

namespace Korean_Api.Models
{
    public class Dramas
    {
        [Key]
        public int Id { get; set; }
        public int ActorId { get; set; }
        public String DramaName { get; set; }
    }
}
