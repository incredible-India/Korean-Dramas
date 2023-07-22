using Microsoft.EntityFrameworkCore;

namespace Korean_Api.Database
{
    public class KoreanContext: DbContext
    {
        public KoreanContext(DbContextOptions<KoreanContext> options) : base(options)
        {

        }

    }
}
