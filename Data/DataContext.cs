using Microsoft.EntityFrameworkCore;
using FinancialTamkeen_BlogAPI.Models;

namespace FinancialTamkeen_BlogAPI.Data
{
    public class DataContext : DbContext
    {
        public DataContext(DbContextOptions<DataContext> options) : base(options)
        {
        }
        public DbSet<Blog> Blog { get; set; }
        public DbSet<User> Users { get; set; }

    }
}