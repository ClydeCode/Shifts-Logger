using Microsoft.EntityFrameworkCore;

namespace Shifts_Logger.Models
{
    public class ShiftContext : DbContext
    {
        public ShiftContext(DbContextOptions<ShiftContext> options)
            : base(options)
        {
        }

        public DbSet<Shift> ShiftsList { get; set; } = null!;
    }
}
