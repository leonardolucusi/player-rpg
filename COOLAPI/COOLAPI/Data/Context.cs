using Microsoft.EntityFrameworkCore;

namespace COOLAPI.Data
{
    public class Context : DbContext
    {
        public Context(DbContextOptions<Context> options): base(options)
        {
        }
        public DbSet<Player> Players { get; set; } = default!;
    }
}
