using Microsoft.EntityFrameworkCore;
using StatApp.API.Models;

namespace StatApp.API.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base (options) { }
        
        public DbSet<Value> Values { get; set; }
    }
}