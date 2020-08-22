using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace GoalAppV2.Models
{
    public class AppDbContext : IdentityDbContext<IdentityUser>
    {
        public AppDbContext(DbContextOptions<AppDbContext> options) : base(options) { }

        public DbSet<Note> Notes { get; set; }


        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 1,
                Title = "The first seed note",
                Description = "A seeded note to test the concept",
                CreatedBy = "Asiel"
            });

            modelBuilder.Entity<Note>().HasData(new Note
            {
                Id = 2,
                Title = "The second seed note",
                Description = "Note body for note 2",
                CreatedBy = "Asiel"
            });
        }
  
    }
}
