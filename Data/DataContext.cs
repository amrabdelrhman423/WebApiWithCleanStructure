using Microsoft.EntityFrameworkCore;
using testapi.Models;

namespace testapi.Data

{
    public class DataContext :DbContext
    {
        public DataContext(DbContextOptions<DataContext> options):base(options)
        { 
             
        }

        public DbSet<Character> characters { get; set; }
        public DbSet<User> Users { get; set; }

    }
}
