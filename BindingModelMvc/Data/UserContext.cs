using BindingModelMvc.DataLayer.Entities;
using Microsoft.EntityFrameworkCore;

namespace BindingModelMvc.DataLayer.Data
{
    public class UserContext : DbContext
    {
        public UserContext(DbContextOptions<UserContext> options) : base(options)
        {
            Database.EnsureCreated();
        }

        public DbSet<User> Users { get; set; }
    }
}
