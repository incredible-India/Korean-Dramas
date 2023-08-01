using Korean_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Korean_Api.Database
{
    public class KoreanContext: DbContext
    {
        public KoreanContext(DbContextOptions<KoreanContext> options) : base(options)
        {

        }
        public DbSet<LeadActors> ActorsTable { get; set; }

        public DbSet<Users> users { get; set; }

        public DbSet<Movies> movies { get; set; }

        public DbSet<FavLead> favActor { get; set; }
        public DbSet<Details> details { get; set; }
        public DbSet<Dramas> DramasTable { get; set; }
        public DbSet<TVShows> TVShowsTable { get; set;}
        public DbSet<TopMovies> TopMoviesTable { get; set;}

    }
}
