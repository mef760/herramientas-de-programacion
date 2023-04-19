using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clase6.Models;

namespace Clase6.Data
{
    public class MenuContext : DbContext
    {
        public MenuContext (DbContextOptions<MenuContext> options)
            : base(options)
        {
        }

        public DbSet<Clase6.Models.Menu> Menu { get; set; } = default!;
        public DbSet<Clase6.Models.Restaurant> Restaurant { get; set; } = default!;

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Menu>()
            .HasMany(p=> p.Restaurants)
            .WithOne(p=> p.Menu)
            .HasForeignKey(p => p.MenuId);
        }
    }
}
