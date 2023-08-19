using System.ComponentModel.DataAnnotations;

namespace Korean_Api.Models
{
    public class LeadActors
    {
        [Key]
        public int Id { get; set; }
        public string Name { get; set; }
        public int Age { get; set; }
        public string Gender { get; set; }
        public string Nationality { get; set; }
        public int NoOfMovies { get; set; } 
        public string MaritalStatus { get; set; }
        public string LatestMovie { get; set;}
        public string DOB { get; set; }
        public int NoOfAwards { get; set;}

        public string ImageURL { get; set; }

    }
}





