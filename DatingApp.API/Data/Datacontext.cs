using DatingApp.API.Models;
using Microsoft.EntityFrameworkCore;

namespace DatingApp.API.Data
{
    public class Datacontext : DbContext
    {
        public Datacontext(DbContextOptions<Datacontext> option) : base (option) {}

        public DbSet<Value> Value { get; set; }
        public DbSet<User> Users { get; set; }
    }
}