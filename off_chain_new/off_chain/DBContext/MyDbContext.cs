using Microsoft.EntityFrameworkCore;
using off_chain.Models;
using System.Drawing;

namespace off_chain.DBContext
{
    public class MyDbContext:DbContext
    {
        public MyDbContext(DbContextOptions<MyDbContext> options) : base(options)
        {
        }
        public DbSet<User> Users { get; set; }
        public DbSet<Event> Events { get; set; }
        public DbSet<Ticket> Tickets { get; set; }
        public DbSet<TicketCategory> TicketCategories { get; set; }

        public DbSet<Payment> Payments { get; set; }
        public DbSet<TicketPurchased> TicketPurchaseds { get; set; }

        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<User>().ToTable("User");
            modelBuilder.Entity<Event>().ToTable("Event");

            modelBuilder.Entity<Ticket>().ToTable("Ticket");
            modelBuilder.Entity<TicketCategory>().ToTable("TicketCategory");

            modelBuilder.Entity<Payment>().ToTable("Payment");

            modelBuilder.Entity<TicketPurchased>().ToTable("TicketPurchased");

        }
    }
}
