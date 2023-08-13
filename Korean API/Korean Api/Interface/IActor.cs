using Korean_Api.Models;

namespace Korean_Api.Interface
{
    public interface IActor
    {
        public void DeleteShowBYID(int id);
        public LeadActors NewActor(LeadActors lActor);
        public LeadActors GetActorById(int id);
        public int DeleteActorById(int id);
        public List<LeadActors> GetAllActors();
        public Movies AddMovies(TempMovies temp);
        public List<string> GetAllMoviesByActorId(int Actorid);
        public int UpdateActorInfo (int id, LeadActors actor);
        public Details AddDetailsOfActor (Details detail);
        public Dramas AddDramas(TempDramas tempd);
        public TVShows AddTvShows(TempShows temps);
        public TopMovies AddTopShows(TopMovies show);
        public List<TopMovies> GetAllTopMovies();
        public Details GetDetailsById(int Actorid);
        public List<Movies> GetAllMovies();
        public List<Dramas> GetAllDramas();
        public List<TVShows> GetAllTvShows();
    }
}
