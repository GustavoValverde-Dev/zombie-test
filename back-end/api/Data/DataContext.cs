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
        public DbSet<ResourceType> ResourceTypes { get; set; }
        public DbSet<ResourceEntry> ResourceEntries { get; set; }
        public DbSet<ResourceDeparture> ResourceDepartures { get; set; }
        public DbSet<ResourceStock> ResourceStocks { get; set; }
        public DbSet<User> Users { get; set; }
        public DbSet<Group> Groups { get; set; }
        public DbSet<Function> Functions { get; set; }
        public DbSet<ResourceHist> ResourceHists { get; set; }
        public DbSet<UserGroup> UserGroups { get; set; } 
        public DbSet<TokenLog> TokenLogs { get; set; } 
    }
}