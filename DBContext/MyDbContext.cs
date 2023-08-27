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
        public DbSet<Event> Events { get; set; }
        protected override void OnModelCreating(ModelBuilder modelBuilder)
        {
            modelBuilder.Entity<Event>().ToTable("Event");

        }
    }
}
