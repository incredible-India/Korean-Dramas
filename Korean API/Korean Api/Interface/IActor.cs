using Korean_Api.Models;

namespace Korean_Api.Interface
{
    public interface IActor
    {
        public LeadActors NewActor(LeadActors lActor);
        public LeadActors GetActorById(int id);
        public int DeleteActorById(int id);
        public List<LeadActors> GetAllActors();
        public Movies AddMovies(TempMovies temp);
        public List<string> GetAllMoviesByActorId(int Actorid);
    }
}
