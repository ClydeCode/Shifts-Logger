﻿using Microsoft.EntityFrameworkCore;

namespace API.Models
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
