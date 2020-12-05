using api.Models;
using Microsoft.EntityFrameworkCore;

namespace api.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options)
            : base(options)
        {}

        public DbSet<Resource> Resources { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<ResourceHist> ResourceHists { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; } 
    }
}