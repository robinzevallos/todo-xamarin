using Microsoft.EntityFrameworkCore;
using Todo.Interfaces;
using Todo.Models;
using Xamarin.Forms;

namespace Todo.Context
{
    public class AppDbContext : DbContext
    {
        public DbSet<TodoModel> Todos { get; set; }

        public AppDbContext()
        {
            //Database.EnsureDeleted();
            Database.EnsureCreated();
        }

        protected override void OnConfiguring(DbContextOptionsBuilder optionsBuilder)
        {
            var dbPath = DependencyService.Get<IDbPath>().GetPath("todoDb.sqlite");

            optionsBuilder.UseSqlite($"Filename={dbPath}");
        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<TodoModel>()
                .HasData(
                    new TodoModel 
                    { 
                        Id = 1, 
                        Description = "To do database" 
                    }
                );
        }
    }
}
