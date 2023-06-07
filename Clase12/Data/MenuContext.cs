using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;
using Microsoft.EntityFrameworkCore;
using Clase6.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.AspNetCore.Identity;

namespace Clase6.Data
{
    public class MenuContext : IdentityDbContext
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
            .WithMany(p=> p.Menus)
            .UsingEntity("MenuRestaurant");

            base.OnModelCreating(modelBuilder);
        }
    }
}
