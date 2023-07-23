using Korean_Api.Models;
using Microsoft.EntityFrameworkCore;

namespace Korean_Api.Database
{
    public class KoreanContext: DbContext
    {
        public KoreanContext(DbContextOptions<KoreanContext> options) : base(options)
        {

        }
        public DbSet<LeadActors> LeadActors { get; set; }

        public DbSet<Users> users { get; set; }

    }
}
