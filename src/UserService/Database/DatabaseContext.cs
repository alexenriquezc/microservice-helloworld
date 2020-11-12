using Microsoft.EntityFrameworkCore;
using UserService.Database.Entities;

namespace UserService.Database
{
    public class DatabaseContext: DbContext
    {
        public DbSet<User> Users{get;set;}

        public DatabaseContext(DbContextOptions<DatabaseContext> options): base(options)
        {
            
        }  
    }
}