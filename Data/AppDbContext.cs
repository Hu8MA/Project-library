using Labrary2023.Models;
using Microsoft.AspNetCore.Identity.EntityFrameworkCore;
using Microsoft.EntityFrameworkCore;

namespace Labrary2023.Data
{
    public class AppDbContext : IdentityDbContext
    {
        public AppDbContext(DbContextOptions<AppDbContext> opt) : base(opt) { }
        

        public DbSet<author> authors { get; set; }
        public DbSet<book> books { get; set; }
        public DbSet<book_author> book_Authors { get; set; }
        public DbSet<category> categories { get; set; }
        public DbSet<fine> fines { get; set; }
        public DbSet<fine_payment> fine_Payments { get; set; }
        public DbSet<loan> loans { get; set; }
        public DbSet<member> members { get; set; }
        public DbSet<member_state> member_States { get; set; }
        public DbSet<reservation> reservations { get; set; }
        public DbSet<reservation_state> reservation_States { get; set; }

    }
}
