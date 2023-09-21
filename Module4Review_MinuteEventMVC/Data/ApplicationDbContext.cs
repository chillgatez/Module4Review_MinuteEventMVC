using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;
using Module4Review_MinuteEventMVC.Models;

namespace Module4Review_MinuteEventMVC.Data
{
    public class ApplicationDbContext : IdentityDbContext
    {
        public DbSet<Event> Events { get; set; } = default!;
        public DbSet<User>  Users { get; set; } = default!;
        public DbSet<UserEvent> UserEvents { get; set; } = default!;


        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options) : base(options)
        {

        }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            base.OnModelCreating(modelBuilder);

            //information tables
            modelBuilder.Entity<Event>().HasData(
                new Event { Id = 1, Name = "Graduation", Description = "You passed... your classes.", City = "Memphis", State = "TN", Date = DateTime.Parse("2023-10-13 17:00:00") },
                new Event { Id = 2, Name = "Wedding", Description = "You passed... up on the single life.", City = "New York", State = "NY", Date = DateTime.Parse("2033-07-10 17:00:00") },
                new Event { Id = 3, Name = "Funeral", Description = "You passed... away.", City = "Yosimite", State = "CA", Date = DateTime.Parse("2093-06-15 16:20:00") });

            modelBuilder.Entity<User>().HasData(
               new User { Id = 1, UserName = "NotMe", Email = "notmyemail@gmail.com" },
               new User { Id = 2, UserName = "SomebodyElse", Email = "somebodysemail@gmail.com" });

            modelBuilder.Entity<UserEvent>().HasData(
                new UserEvent { Id = 1, UserId = 1, EventId = 1 },
                new UserEvent { Id = 2, UserId = 2, EventId = 3 },
                new UserEvent { Id = 3, UserId = 1, EventId = 2 });
        }

        public DbSet<Module4Review_MinuteEventMVC.Models.Event> Event { get; set; } = default!;
        public DbSet<Module4Review_MinuteEventMVC.Models.User> User { get; set; } = default!;
        public DbSet<Module4Review_MinuteEventMVC.Models.UserEvent> UserEvent { get; set; } = default!;
    }
}