using GymSis.Models;
using Microsoft.EntityFrameworkCore;

namespace GymSis.Data
{
    public class ApplicationDbContext: DbContext
    {

        public ApplicationDbContext(DbContextOptions<ApplicationDbContext> options):base(options)   
        {

        }

        public DbSet<Gym> Gyms { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Membership> Memberships { get; set; }
        public DbSet<Sales> Sales { get; set; }

    }
}
