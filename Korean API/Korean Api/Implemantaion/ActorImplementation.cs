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

        public Details AddDetailsOfActor(Details detail)
        {
            Details? det = new Details()
            {
                ActorId = detail.ActorId,
                Detail = detail.Detail
            };
            _koreanContext.details.Add(det);
            _koreanContext.SaveChanges();

            return det;
        }

        public Dramas AddDramas(TempDramas tempd)
        {
            Dramas? drama = new Dramas()
            {
                ActorId = tempd.ActorId,
                DramaName = string.Join(",", tempd.DramaName)
            };
            _koreanContext.DramasTable.Add(drama);
            _koreanContext.SaveChanges();

            return drama;
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

        public TopMovies AddTopShows(TopMovies show)
        {
            TopMovies? topShow = new TopMovies()
            {
                ActorName = show.ActorName,
                ShowType = show.ShowType,
                MovieName = show.MovieName
            };
            _koreanContext.TopMoviesTable.Add(topShow);
            _koreanContext.SaveChanges();

            return topShow;
        }

        public TVShows AddTvShows(TempShows temps)
        {
            TVShows? tvShows = new TVShows()
            {
                ActorId = temps.ActorId,
                TvShows = string.Join(",", temps.TvShows)
            };
            _koreanContext.TVShowsTable.Add(tvShows);
            _koreanContext.SaveChanges();

            return tvShows;
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

        public List<TopMovies> GetAllTopMovies()
        {
            List<TopMovies> m = _koreanContext.TopMoviesTable.ToList();
            return m;
        }

        public Details GetDetailsById(int Actorid)
        {
            Details? d = _koreanContext.details.Where(x=> x.Id == Actorid).FirstOrDefault();
            return d;
        }

        public LeadActors NewActor(LeadActors lActor)
        {
            _koreanContext.ActorsTable.Add(lActor);
            _koreanContext.SaveChanges();
            return lActor;
        }

        public int UpdateActorInfo(int id, LeadActors actor)
        {
            //checking if the id entered exists in the db
            var ac = _koreanContext.ActorsTable.Where(x => x.Id == id);

            if(ac.Any())
            {
                var a = ac.FirstOrDefault();

                a.NoOfAwards =actor.NoOfAwards;
                a.NoOfMovies =actor.NoOfMovies;
                a.LatestMovie =actor.LatestMovie;
                a.MaritalStatus =actor.MaritalStatus;
                a.Age =actor.Age;
                a.DOB =actor.DOB;
                a.Nationality =actor.Nationality;
                a.Gender =actor.Gender;
                a.Name =actor.Name;

               int  b = _koreanContext.SaveChanges();
                return b;
            }
            else
            {
                return 0;
            }


        }
    }
}
