using Korean_Api.Database;
using Korean_Api.Interface;
using Korean_Api.Models;
using System.Numerics;
using System.Text.Json;
namespace Korean_Api.Implemantaion
{
    public class ActorImplementation : IActor
    {
        private readonly KoreanContext _koreanContext;
        public ActorImplementation(KoreanContext koreanContext)
        {
            _koreanContext = koreanContext;
        }

        public Movies AddMovies(TempMovies temp)
        {
            Movies? movie = new Movies()
            {
                ActorId = temp.ActorId,
                movies = string.Join(",", temp.movies)
            };
            _koreanContext.movies.Add(movie);
            _koreanContext.SaveChanges();

            return movie;
        }

        public int DeleteActorById(int id)
        {
            LeadActors? hero = _koreanContext.ActorsTable.Where(x=>x.Id == id).FirstOrDefault();
            if (hero != null)
            {
                _koreanContext.Remove(hero);
                _koreanContext.SaveChanges();
                return 1;

            }
            else
            {
                return 0;
            }  
        }

        public LeadActors GetActorById(int id)
        {
            LeadActors? a = _koreanContext.ActorsTable.Where(x=>x.Id == id).FirstOrDefault(); 
            return a;
        }

        public List<LeadActors> GetAllActors()
        {
            List<LeadActors>? list = _koreanContext.ActorsTable.ToList();
            return list;
        }

        public List<string> GetAllMoviesByActorId(int Actorid)
        {
            bool isExist = _koreanContext.ActorsTable.Where(x=>x.Id == Actorid).Any();
            if(isExist)
            {
                Movies mov = _koreanContext.movies.Where(x => x.Id == Actorid).FirstOrDefault();
                List<string> m = mov.movies.Split(",").ToList();
                return m;
            }
            else
            {
                return null;
            }
         
        }

        public LeadActors NewActor(LeadActors lActor)
        {
            _koreanContext.ActorsTable.Add(lActor);
            _koreanContext.SaveChanges();
            return lActor;
        }
    }
}
