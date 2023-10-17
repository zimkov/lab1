using Example.Models;
using Microsoft.EntityFrameworkCore;

namespace Example.Context
{
    public class ApplicationContext : DbContext

    {
        public DbSet<User> Users => Set<User>(); 

        public ApplicationContext(DbContextOptions<ApplicationContext> options)
            :base(options)
        {
            Database.EnsureCreated();   // создаем базу данных при первом обращении
        }

        
    }
}
