using BazarCore.Entities;
using BazarCore.Models;
using Bogus;
using Microsoft.EntityFrameworkCore;

namespace BazarCore.Data.Context
{
    public class MyContext : DbContext
    {
        public MyContext(DbContextOptions<MyContext> options)
            : base(options)
        {

        }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>()
                .HasOne(u => u.Organizer)
                .WithOne(o => o.User)
                .HasForeignKey<Organizer>(o => o.UserId)
                .OnDelete(DeleteBehavior.Cascade);

            //// for seed events
            //var ids = 1;
            //var stock = new Faker<Organizer>()
            //    .RuleFor(m => m.UserId, f => ids++)
            //    .RuleFor(m => m.ComercialName, f => f.Company.CompanyName());

            //// generate 1000 items
            //modelBuilder
            //    .Entity<Organizer>()
            //    .HasData(stock.GenerateBetween(1000, 1000));
        }

        public DbSet<User> Users { get; set; }
        public DbSet<Organizer> Organizers { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<EventSession> EventSessions { get; set; }
        public DbSet<Category> Categories { get; set; }
        public DbSet<City> Cities { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
    }
}
